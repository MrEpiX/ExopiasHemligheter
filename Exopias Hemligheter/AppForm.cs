using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Reflection;

using GDataDB;
using GDataDB.Linq;

public partial class AppForm : Form
{
    // Menu
    private System.Windows.Forms.Button EnemyModeButton;
    private System.Windows.Forms.Button EventModeButton;
    private System.Windows.Forms.Label TitleLabel;
    private System.Windows.Forms.PictureBox TitleLogo;
    private System.Windows.Forms.Button LootModeButton;
    private System.Windows.Forms.Button OnlineButton;
    private System.Windows.Forms.TextBox EmailBox;
    private System.Windows.Forms.TextBox PasswordBox;

    // Enemy Mode
    private System.Windows.Forms.TabControl TabController;
    private System.Windows.Forms.ComboBox EnemyRankDropdown;
    private System.Windows.Forms.ComboBox EnemyFocusDropdown;
    private System.Windows.Forms.ComboBox EnemyTypeDropdown;
    private System.Windows.Forms.Button CreateEnemyButton;
    private System.Windows.Forms.Button RemoveEnemyButton;
    private System.Windows.Forms.ComboBox EnemyVariantDropdown;
    private System.Windows.Forms.ComboBox EnemyTerrainDropdown;
    private System.Windows.Forms.Button EnemyTerrainButton;

    // Event Mode
    private System.Windows.Forms.TabControl EventTabController;
    private System.Windows.Forms.ComboBox TerrainEventDropdown;
    private System.Windows.Forms.ComboBox EventTypeDropdown;
    private System.Windows.Forms.CheckBox NPCEventCheckBox;
    private System.Windows.Forms.CheckBox LocationEventCheckBox;
    private System.Windows.Forms.Button CreateEventButton;


    private List<EnemyPage> tabList;
    private List<RankContainer> statList;
    private List<EnemyType> enemyTypes;
    private List<Terrain> terrains;
    private List<TerrainType> terrainTypes;
    private List<Enemy> enemies;
    private List<WeatherType> weatherTypes;
    private List<SeasonType> seasonTypes;

    private Random Rand;

    private string CurrentMode;

    private bool downloaded;

    #region Initializes and Core
    public AppForm()
    {
        InitializeComponent();
    }

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool AllocConsole();
    private void AppForm_Load(object sender, EventArgs e)
    {
        AllocConsole();
        Initialize();
    }

    private void PrintToConsole(string p_string)
    {
        Console.WriteLine(p_string);
    }

    private void PrintToConsole(string p_string, object p_object1)
    {
        Console.WriteLine(p_string, p_object1);
    }

    private void PrintToConsole(string p_string, object p_object1, object p_object2)
    {
        Console.WriteLine(p_string, p_object1, p_object2);
    }

    private void Initialize()
    {
        tabList = new List<EnemyPage>();
        statList = new List<RankContainer>();
        enemyTypes = new List<EnemyType>();
        terrainTypes = new List<TerrainType>();
        terrains = new List<Terrain>();
        enemies = new List<Enemy>();
        weatherTypes = new List<WeatherType>();
        seasonTypes = new List<SeasonType>();

        Rand = new Random(0);

        downloaded = false;

        InitializeMenu();
    }
    #endregion
    
    #region Menu
    private void OnlineButton_Click(object sender, EventArgs e)
    {
        if (EmailBox.Text == "" || PasswordBox.Text == "" || downloaded) { return; }

        PrintToConsole("Connecting");
        DatabaseClient client = new DatabaseClient(EmailBox.Text, PasswordBox.Text);

        const string dbName = "Exopias Hemligheter - Data";
        PrintToConsole("Opening database \"{0}\".", dbName);
        IDatabase database = client.GetDatabase(dbName);

        string tableName;

        // Load and save all the stats
        for (int i = 0; i < 5; i++)
        {
            statList.Add(new RankContainer());
            statList[statList.Count - 1].rank = i + 1;

            tableName = "Fiender_Rank" + (i + 1).ToString();
            PrintToConsole("Opening table \"{0}\".", tableName);
            ITable<FocusStats> table = database.GetTable<FocusStats>(tableName);

            PrintToConsole("Reading rows.");
            IList<IRow<FocusStats>> rows = table.FindAll();

            for (int j = 0; j < 6; j++)
            {
                PrintToConsole("Reading row \"{0}\" and saving it to statList.", j);
                IRow<FocusStats> row = rows[j];
                statList[i].focuses.Add(row.Element);
            }
        }
            
        // Load and save all the enemy types
        tableName = "Fiender";
        PrintToConsole("Opening table \"{0}\".", tableName);
        ITable<EnemyType> enemyTypeTable = database.GetTable<EnemyType>(tableName);

        PrintToConsole("Reading rows.");
        IList<IRow<EnemyType>> enemyTypeRows = enemyTypeTable.FindAll();

        for (int i = 0; i < enemyTypeRows.Count; i++)
        {
            IRow<EnemyType> row = enemyTypeRows[i];
            enemyTypes.Add(row.Element);
            PrintToConsole("Saving row {0}: \"{1}\" to enemyTypes.", i, enemyTypes[i].Name);
        }

        // Load and save all the enemy variants
        for (int i = 0; i < enemyTypes.Count; i++)
        {
            tableName = enemyTypes[i].Name;

            PrintToConsole("Opening table \"{0}\".", tableName);
            ITable<EnemyVariant> enemyVariantTable = database.GetTable<EnemyVariant>(tableName);

            PrintToConsole("Reading rows.");
            IList<IRow<EnemyVariant>> enemyVariantRows = enemyVariantTable.FindAll();

            enemies.Add(new Enemy());
            enemies[enemies.Count - 1].name = tableName;
            PrintToConsole("Saving {0} to Enemies[{1}].Name.", tableName, enemies.Count - 1);
            for (int j = 0; j < enemyVariantRows.Count; j++)
            {
                IRow<EnemyVariant> row = enemyVariantRows[j];
                PrintToConsole("Saving {0} as a variant.", enemyVariantRows[j].Element.Variant);
                enemies[enemies.Count - 1].variantList.Add(row.Element);
            }
        }

        // Load and save all terrain types
        tableName = "Terräng";
        PrintToConsole("Opening table \"{0}\".", tableName);
        ITable<TerrainType> terrainTypeTable = database.GetTable<TerrainType>(tableName);

        PrintToConsole("Reading rows.");
        IList<IRow<TerrainType>> terrainTypeRows = terrainTypeTable.FindAll();

        for (int i = 0; i < terrainTypeRows.Count; i++)
        {
            IRow<TerrainType> row = terrainTypeRows[i];
            terrainTypes.Add(row.Element);
            PrintToConsole("Saving row {0}: \"{1}\" to terrains.", i, terrainTypes[i].Name);
        }

        // Load and save all the terrain Enemies
        for (int i = 0; i < terrainTypes.Count; i++)
        {
            tableName = "Fiender"+terrainTypes[i].Name;

            PrintToConsole("Opening table \"{0}\".", tableName);
            enemyTypeTable = database.GetTable<EnemyType>(tableName);

            PrintToConsole("Reading rows.");
            enemyTypeRows = enemyTypeTable.FindAll();

            terrains.Add(new Terrain());
            terrains[terrains.Count - 1].Name = tableName;
            PrintToConsole("Saving {0} to terrains[{1}].Name.", tableName, terrains.Count - 1);
            for (int j = 0; j < enemyTypeRows.Count; j++)
            {
                IRow<EnemyType> row = enemyTypeRows[j];
                PrintToConsole("Saving {0} as an enemy in {1} terrain.", enemyTypeRows[j].Element.Name, tableName);
                terrains[terrains.Count - 1].Enemies.Add(row.Element);
            }
        }

        // Load and save all the season types
        tableName = "Årstider";
        PrintToConsole("Opening table \"{0}\".", tableName);
        ITable<SeasonType> seasonTypeTable = database.GetTable<SeasonType>(tableName);

        PrintToConsole("Reading rows.");
        IList<IRow<SeasonType>> seasonTypeRows = seasonTypeTable.FindAll();

        for (int i = 0; i < seasonTypeRows.Count; i++)
        {
            IRow<SeasonType> row = seasonTypeRows[i];
            seasonTypes.Add(row.Element);
            PrintToConsole("Saving row {0}: \"{1}\" to seasonTypes.", i, seasonTypes[i].Name);
        }

        // Load and save all the weather types
        tableName = "Väder";
        PrintToConsole("Opening table \"{0}\".", tableName);
        ITable<WeatherType> weatherTypeTable = database.GetTable<WeatherType>(tableName);

        PrintToConsole("Reading rows.");
        IList<IRow<WeatherType>> weatherTypeRows = weatherTypeTable.FindAll();

        for (int i = 0; i < weatherTypeRows.Count; i++)
        {
            IRow<WeatherType> row = weatherTypeRows[i];
            weatherTypes.Add(row.Element);
            PrintToConsole("Saving row {0}: \"{1}\" to weatherTypes.", i, weatherTypes[i].Name);
        }

        downloaded = true;
        PrintToConsole("Loading and saving complete.");
    }

    private void EnemyModeButton_Click(object sender, EventArgs e)
    {
        InitializeEnemyMode();
    }

    private void EventModeButton_Click(object sender, EventArgs e)
    {
        InitializeEventMode();
    }

    private void InitializeMenu()
    {
        Controls.Clear();
        CurrentMode = "Menu";
        this.EnemyModeButton = new System.Windows.Forms.Button();
        this.EventModeButton = new System.Windows.Forms.Button();
        this.TitleLabel = new System.Windows.Forms.Label();
        this.TitleLogo = new System.Windows.Forms.PictureBox();
        this.LootModeButton = new System.Windows.Forms.Button();
        this.OnlineButton = new System.Windows.Forms.Button();
        this.EmailBox = new System.Windows.Forms.TextBox();
        this.PasswordBox = new System.Windows.Forms.TextBox();
        ((System.ComponentModel.ISupportInitialize)(this.TitleLogo)).BeginInit();
        // 
        // EmailBox
        // 
        this.EmailBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.EmailBox.Location = new System.Drawing.Point(195, 267);
        this.EmailBox.Name = "EmailBox";
        this.EmailBox.Size = new System.Drawing.Size(100, 20);
        this.EmailBox.TabIndex = 31;
        // 
        // PasswordBox
        // 
        this.PasswordBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.PasswordBox.Location = new System.Drawing.Point(300, 267);
        this.PasswordBox.Name = "PasswordBox";
        this.PasswordBox.Size = new System.Drawing.Size(100, 20);
        this.PasswordBox.TabIndex = 32;
        this.PasswordBox.UseSystemPasswordChar = true;
        // 
        // OnlineButton
        // 
        this.OnlineButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.OnlineButton.Location = new System.Drawing.Point(405, 266);
        this.OnlineButton.Name = "OnlineButton";
        this.OnlineButton.Size = new System.Drawing.Size(100, 22);
        this.OnlineButton.TabIndex = 6;
        this.OnlineButton.Text = "Uppdatera";
        this.OnlineButton.UseVisualStyleBackColor = true;
        this.OnlineButton.Click += new System.EventHandler(this.OnlineButton_Click);
        // 
        // EnemyModeButton
        // 
        this.EnemyModeButton.Location = new System.Drawing.Point(256, 104);
        this.EnemyModeButton.Name = "EnemyModeButton";
        this.EnemyModeButton.Size = new System.Drawing.Size(188, 34);
        this.EnemyModeButton.TabIndex = 0;
        this.EnemyModeButton.Text = "Fiender";
        this.EnemyModeButton.UseVisualStyleBackColor = true;
        this.EnemyModeButton.Click += new System.EventHandler(this.EnemyModeButton_Click);
        // 
        // EventModeButton
        // 
        this.EventModeButton.Location = new System.Drawing.Point(256, 154);
        this.EventModeButton.Name = "EventModeButton";
        this.EventModeButton.Size = new System.Drawing.Size(188, 34);
        this.EventModeButton.TabIndex = 1;
        this.EventModeButton.Text = "Events";
        this.EventModeButton.UseVisualStyleBackColor = true;
        this.EventModeButton.Click += new System.EventHandler(this.EventModeButton_Click);
        // 
        // LootModeButton
        // 
        this.LootModeButton.Location = new System.Drawing.Point(256, 204);
        this.LootModeButton.Name = "LootModeButton";
        this.LootModeButton.Size = new System.Drawing.Size(188, 34);
        this.LootModeButton.TabIndex = 4;
        this.LootModeButton.Text = "Loot";
        this.LootModeButton.UseVisualStyleBackColor = true;
        // 
        // TitleLabel
        // 
        this.TitleLabel.Font = new System.Drawing.Font("Gentium Book Basic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.TitleLabel.Location = new System.Drawing.Point(12, 9);
        this.TitleLabel.Name = "TitleLabel";
        this.TitleLabel.Size = new System.Drawing.Size(500, 85);
        this.TitleLabel.TabIndex = 2;
        this.TitleLabel.Text = "Exopias Hemligheter";
        this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // TitleLogo
        // 
        this.TitleLogo.Image = global::Exopias_Hemligheter.Properties.Resources.Exopia_Logo;
        this.TitleLogo.Location = new System.Drawing.Point(12, 0);
        this.TitleLogo.Name = "TitleLogo";
        this.TitleLogo.Size = new System.Drawing.Size(180, 317);
        this.TitleLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.TitleLogo.TabIndex = 3;
        this.TitleLogo.TabStop = false;

        this.Controls.Add(this.LootModeButton);
        this.Controls.Add(this.TitleLogo);
        this.Controls.Add(this.TitleLabel);
        this.Controls.Add(this.EventModeButton);
        this.Controls.Add(this.EnemyModeButton);
        this.Controls.Add(this.PasswordBox);
        this.Controls.Add(this.EmailBox);
        this.Controls.Add(this.OnlineButton);
        ((System.ComponentModel.ISupportInitialize)(this.TitleLogo)).EndInit();
    }

    private void InitializeEnemyMode()
    {
        Controls.Clear();
        CurrentMode = "Enemy";
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppForm));
        this.TabController = new System.Windows.Forms.TabControl();
        this.EnemyTypeDropdown = new System.Windows.Forms.ComboBox();
        this.EnemyRankDropdown = new System.Windows.Forms.ComboBox();
        this.EnemyFocusDropdown = new System.Windows.Forms.ComboBox();
        this.CreateEnemyButton = new System.Windows.Forms.Button();
        this.RemoveEnemyButton = new System.Windows.Forms.Button();
        this.EnemyVariantDropdown = new System.Windows.Forms.ComboBox();
        this.EnemyTerrainDropdown = new System.Windows.Forms.ComboBox();
        this.EnemyTerrainButton = new System.Windows.Forms.Button();
        this.TabController.SuspendLayout();
        this.SuspendLayout();
        // 
        // TabController
        // 
        this.TabController.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
        | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.TabController.Location = new System.Drawing.Point(12, 12);
        this.TabController.Name = "TabController";
        this.TabController.SelectedIndex = 0;
        this.TabController.Size = new System.Drawing.Size(501, 237);
        this.TabController.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
        this.TabController.TabIndex = 0;
        // 
        // EnemyTypeDropdown
        // 
        this.EnemyTypeDropdown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.EnemyTypeDropdown.FormattingEnabled = true;
        this.EnemyTypeDropdown.Location = new System.Drawing.Point(156, 255);
        this.EnemyTypeDropdown.Name = "EnemyTypeDropdown";
        this.EnemyTypeDropdown.Size = new System.Drawing.Size(111, 21);
        this.EnemyTypeDropdown.TabIndex = 1;
        this.EnemyTypeDropdown.SelectedIndexChanged += new System.EventHandler(this.EnemyTypeDropdown_SelectedIndexChanged);
        // 
        // EnemyRankDropdown
        // 
        this.EnemyRankDropdown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.EnemyRankDropdown.FormattingEnabled = true;
        this.EnemyRankDropdown.Location = new System.Drawing.Point(273, 284);
        this.EnemyRankDropdown.Name = "EnemyRankDropdown";
        this.EnemyRankDropdown.Size = new System.Drawing.Size(111, 21);
        this.EnemyRankDropdown.TabIndex = 3;
        // 
        // EnemyFocusDropdown
        // 
        this.EnemyFocusDropdown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.EnemyFocusDropdown.FormattingEnabled = true;
        this.EnemyFocusDropdown.Location = new System.Drawing.Point(273, 255);
        this.EnemyFocusDropdown.Name = "EnemyFocusDropdown";
        this.EnemyFocusDropdown.Size = new System.Drawing.Size(111, 21);
        this.EnemyFocusDropdown.TabIndex = 4;
        // 
        // CreateEnemyButton
        // 
        this.CreateEnemyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.CreateEnemyButton.Location = new System.Drawing.Point(390, 255);
        this.CreateEnemyButton.Name = "CreateEnemyButton";
        this.CreateEnemyButton.Size = new System.Drawing.Size(111, 22);
        this.CreateEnemyButton.TabIndex = 0;
        this.CreateEnemyButton.Text = "Skapa Fiende";
        this.CreateEnemyButton.UseVisualStyleBackColor = true;
        this.CreateEnemyButton.Click += new System.EventHandler(this.CreateEnemyButton_Click);
        // 
        // RemoveEnemyButton
        // 
        this.RemoveEnemyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.RemoveEnemyButton.Location = new System.Drawing.Point(390, 284);
        this.RemoveEnemyButton.Name = "RemoveEnemyButton";
        this.RemoveEnemyButton.Size = new System.Drawing.Size(111, 21);
        this.RemoveEnemyButton.TabIndex = 5;
        this.RemoveEnemyButton.Text = "Ta Bort Fiende";
        this.RemoveEnemyButton.UseVisualStyleBackColor = true;
        this.RemoveEnemyButton.Click += new System.EventHandler(this.RemoveEnemyButton_Click);
        // 
        // EnemyVariantDropdown
        // 
        this.EnemyVariantDropdown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.EnemyVariantDropdown.FormattingEnabled = true;
        this.EnemyVariantDropdown.Location = new System.Drawing.Point(156, 284);
        this.EnemyVariantDropdown.Name = "EnemyVariantDropdown";
        this.EnemyVariantDropdown.Size = new System.Drawing.Size(111, 21);
        this.EnemyVariantDropdown.TabIndex = 33;
        this.EnemyVariantDropdown.SelectedIndexChanged += new System.EventHandler(this.EnemyVariantDropdown_SelectedIndexChanged);
        // 
        // EnemyTerrainDropdown
        // 
        this.EnemyTerrainDropdown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.EnemyTerrainDropdown.FormattingEnabled = true;
        this.EnemyTerrainDropdown.Location = new System.Drawing.Point(23, 255);
        this.EnemyTerrainDropdown.Name = "EnemyTerrainDropdown";
        this.EnemyTerrainDropdown.Size = new System.Drawing.Size(127, 21);
        this.EnemyTerrainDropdown.TabIndex = 34;
        this.EnemyTerrainDropdown.SelectedIndexChanged += new System.EventHandler(this.EnemyTerrainDropdown_SelectedIndexChanged);
        // 
        // EnemyTerrainButton
        // 
        this.EnemyTerrainButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.EnemyTerrainButton.Location = new System.Drawing.Point(23, 283);
        this.EnemyTerrainButton.Name = "EnemyTerrainButton";
        this.EnemyTerrainButton.Size = new System.Drawing.Size(127, 22);
        this.EnemyTerrainButton.TabIndex = 35;
        this.EnemyTerrainButton.Text = "Generera Från Terräng";
        this.EnemyTerrainButton.UseVisualStyleBackColor = true;
        this.EnemyTerrainButton.Click += new System.EventHandler(this.EnemyTerrainButton_Click);
        // 
        // AppForm
        // 
        this.Controls.Add(this.EnemyTerrainButton);
        this.Controls.Add(this.EnemyTerrainDropdown);
        this.Controls.Add(this.EnemyVariantDropdown);
        this.Controls.Add(this.RemoveEnemyButton);
        this.Controls.Add(this.EnemyFocusDropdown);
        this.Controls.Add(this.EnemyRankDropdown);
        this.Controls.Add(this.EnemyTypeDropdown);
        this.Controls.Add(this.CreateEnemyButton);
        this.Controls.Add(this.TabController);
        this.TabController.ResumeLayout(false);

        FillBoxes();
    }

    private void InitializeEventMode()
    {
        Controls.Clear();
        CurrentMode = "Event";
        TerrainEventDropdown = new System.Windows.Forms.ComboBox();
        EventTypeDropdown = new System.Windows.Forms.ComboBox();
        NPCEventCheckBox = new System.Windows.Forms.CheckBox();
        LocationEventCheckBox = new System.Windows.Forms.CheckBox();
        CreateEventButton = new System.Windows.Forms.Button();
        EventTabController = new System.Windows.Forms.TabControl();
        SuspendLayout();
        // 
        // TerrainEventDropdown
        // 
        this.TerrainEventDropdown.FormattingEnabled = true;
        this.TerrainEventDropdown.Location = new System.Drawing.Point(12, 285);
        this.TerrainEventDropdown.Name = "TerrainEventDropdown";
        this.TerrainEventDropdown.Size = new System.Drawing.Size(121, 21);
        this.TerrainEventDropdown.TabIndex = 0;
        // 
        // EventTypeDropdown
        // 
        this.EventTypeDropdown.FormattingEnabled = true;
        this.EventTypeDropdown.Location = new System.Drawing.Point(139, 285);
        this.EventTypeDropdown.Name = "EventTypeDropdown";
        this.EventTypeDropdown.Size = new System.Drawing.Size(121, 21);
        this.EventTypeDropdown.TabIndex = 1;
        this.EventTypeDropdown.SelectedIndexChanged += new System.EventHandler(this.EventTypeDropdown_SelectedIndexChanged);
        // 
        // NPCEventCheckBox
        // 
        this.NPCEventCheckBox.AutoSize = true;
        this.NPCEventCheckBox.Location = new System.Drawing.Point(266, 287);
        this.NPCEventCheckBox.Name = "NPCEventCheckBox";
        this.NPCEventCheckBox.Size = new System.Drawing.Size(52, 17);
        this.NPCEventCheckBox.TabIndex = 2;
        this.NPCEventCheckBox.Text = "NPCs";
        this.NPCEventCheckBox.UseVisualStyleBackColor = true;
        // 
        // LocationEventCheckbox
        // 
        this.LocationEventCheckBox.AutoSize = true;
        this.LocationEventCheckBox.Location = new System.Drawing.Point(324, 287);
        this.LocationEventCheckBox.Name = "LocationEventCheckBox";
        this.LocationEventCheckBox.Size = new System.Drawing.Size(48, 17);
        this.LocationEventCheckBox.TabIndex = 3;
        this.LocationEventCheckBox.Text = "Plats";
        this.LocationEventCheckBox.UseVisualStyleBackColor = true;
        // 
        // CreateEventButton
        // 
        this.CreateEventButton.Location = new System.Drawing.Point(378, 285);
        this.CreateEventButton.Name = "CreateEventButton";
        this.CreateEventButton.Size = new System.Drawing.Size(134, 21);
        this.CreateEventButton.TabIndex = 4;
        this.CreateEventButton.Text = "Skapa Event";
        this.CreateEventButton.UseVisualStyleBackColor = true;
        this.CreateEventButton.Click += new System.EventHandler(this.CreateEventButton_Click);
        // 
        // EventTabController
        // 
        this.EventTabController.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
        | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.EventTabController.Location = new System.Drawing.Point(12, 12);
        this.EventTabController.Name = "EventTabController";
        this.EventTabController.SelectedIndex = 0;
        this.EventTabController.Size = new System.Drawing.Size(501, 264);
        this.EventTabController.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
        this.EventTabController.TabIndex = 0;

        this.Controls.Add(this.EventTabController);
        this.Controls.Add(this.TerrainEventDropdown);
        this.Controls.Add(this.EventTypeDropdown);
        this.Controls.Add(this.NPCEventCheckBox);
        this.Controls.Add(this.LocationEventCheckBox);
        this.Controls.Add(this.CreateEventButton);

        FillBoxes();
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (keyData == Keys.Escape)
        {
            InitializeMenu();
            return true;
        }

        // Call the base class
        return base.ProcessCmdKey(ref msg, keyData);
    }
    #endregion

    #region EnemyMode
    private void CreateEnemyTab()
    {
        tabList.Add(new EnemyPage());
        tabList[tabList.Count - 1].CharacterChestBox.ValueChanged += new System.EventHandler(this.CharacterChestBox_ValueChanged);
        tabList[tabList.Count - 1].CharacterStomachBox.ValueChanged += new System.EventHandler(this.CharacterStomachBox_ValueChanged);
        tabList[tabList.Count - 1].CharacterHeadBox.ValueChanged += new System.EventHandler(this.CharacterHeadBox_ValueChanged);
        tabList[tabList.Count - 1].CharacterLeftArmBox.ValueChanged += new System.EventHandler(this.CharacterLeftArmBox_ValueChanged);
        tabList[tabList.Count - 1].CharacterLeftLegBox.ValueChanged += new System.EventHandler(this.CharacterLeftLegBox_ValueChanged);
        tabList[tabList.Count - 1].CharacterRightArmBox.ValueChanged += new System.EventHandler(this.CharacterRightArmBox_ValueChanged);
        tabList[tabList.Count - 1].CharacterRightLegBox.ValueChanged += new System.EventHandler(this.CharacterRightLegBox_ValueChanged);

        tabList[tabList.Count - 1].CharacterChestBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Box_KeyPress);
        tabList[tabList.Count - 1].CharacterStomachBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Box_KeyPress);
        tabList[tabList.Count - 1].CharacterHeadBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Box_KeyPress);
        tabList[tabList.Count - 1].CharacterLeftArmBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Box_KeyPress);
        tabList[tabList.Count - 1].CharacterLeftLegBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Box_KeyPress);
        tabList[tabList.Count - 1].CharacterRightArmBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Box_KeyPress);
        tabList[tabList.Count - 1].CharacterRightLegBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Box_KeyPress);
        tabList[tabList.Count - 1].CharacterTotalBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Box_KeyPress);

        tabList[tabList.Count - 1].StrengthBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Box_KeyPress);
        tabList[tabList.Count - 1].ToughnessBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Box_KeyPress);
        tabList[tabList.Count - 1].IntellectBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Box_KeyPress);
        tabList[tabList.Count - 1].MindBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Box_KeyPress);
        tabList[tabList.Count - 1].AgilityBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Box_KeyPress);

        /*tabList[tabList.Count - 1].CharacterStomachBox.
        tabList[tabList.Count - 1].CharacterHeadBox.
        tabList[tabList.Count - 1].CharacterLeftArmBox
        tabList[tabList.Count - 1].CharacterLeftLegBox
        tabList[tabList.Count - 1].CharacterRightArmBox
        tabList[tabList.Count - 1].CharacterRightLegBox
        tabList[tabList.Count - 1].CharacterTotalBox*/

        if (statList.Count > 0)
        {
            tabList[tabList.Count - 1].StrengthBox.Text = statList[EnemyRankDropdown.SelectedIndex].focuses[EnemyFocusDropdown.SelectedIndex].Strength.ToString();
            tabList[tabList.Count - 1].StrengthValueLabel.Text = "(" + tabList[tabList.Count - 1].StrengthBox.Text + ")";
            tabList[tabList.Count - 1].ToughnessBox.Text = statList[EnemyRankDropdown.SelectedIndex].focuses[EnemyFocusDropdown.SelectedIndex].Toughness.ToString();
            tabList[tabList.Count - 1].ToughnessValueLabel.Text = "(" + tabList[tabList.Count - 1].ToughnessBox.Text + ")";
            tabList[tabList.Count - 1].IntellectBox.Text = statList[EnemyRankDropdown.SelectedIndex].focuses[EnemyFocusDropdown.SelectedIndex].Intellect.ToString();
            tabList[tabList.Count - 1].IntellectValueLabel.Text = "(" + tabList[tabList.Count - 1].IntellectBox.Text + ")";
            tabList[tabList.Count - 1].MindBox.Text = statList[EnemyRankDropdown.SelectedIndex].focuses[EnemyFocusDropdown.SelectedIndex].Mind.ToString();
            tabList[tabList.Count - 1].MindValueLabel.Text = "(" + tabList[tabList.Count - 1].MindBox.Text + ")";
            tabList[tabList.Count - 1].AgilityBox.Text = statList[EnemyRankDropdown.SelectedIndex].focuses[EnemyFocusDropdown.SelectedIndex].Agility.ToString();
            tabList[tabList.Count - 1].AgilityValueLabel.Text = "(" + tabList[tabList.Count - 1].AgilityBox.Text + ")";
            tabList[tabList.Count - 1].DamageBox.Text = statList[EnemyRankDropdown.SelectedIndex].focuses[EnemyFocusDropdown.SelectedIndex].Damage.ToString();
            tabList[tabList.Count - 1].DamageValueLabel.Text = "(" + tabList[tabList.Count - 1].DamageBox.Text + ")";

            tabList[tabList.Count - 1].CharacterTotalBox.Text = statList[EnemyRankDropdown.SelectedIndex].focuses[EnemyFocusDropdown.SelectedIndex].Health.ToString();
            tabList[tabList.Count - 1].CharacterHeadBox.Text = Math.Round(statList[EnemyRankDropdown.SelectedIndex].focuses[EnemyFocusDropdown.SelectedIndex].Health * 0.5f-2).ToString();
            tabList[tabList.Count - 1].CharacterRightArmBox.Text = Math.Round(statList[EnemyRankDropdown.SelectedIndex].focuses[EnemyFocusDropdown.SelectedIndex].Health * 0.5f-2).ToString();
            tabList[tabList.Count - 1].CharacterLeftArmBox.Text = Math.Round(statList[EnemyRankDropdown.SelectedIndex].focuses[EnemyFocusDropdown.SelectedIndex].Health * 0.5f-2).ToString();
            tabList[tabList.Count - 1].CharacterChestBox.Text = Math.Round(statList[EnemyRankDropdown.SelectedIndex].focuses[EnemyFocusDropdown.SelectedIndex].Health * 0.5f+1).ToString();
            tabList[tabList.Count - 1].CharacterStomachBox.Text = Math.Round(statList[EnemyRankDropdown.SelectedIndex].focuses[EnemyFocusDropdown.SelectedIndex].Health * 0.5f).ToString();
            tabList[tabList.Count - 1].CharacterRightLegBox.Text = Math.Round(statList[EnemyRankDropdown.SelectedIndex].focuses[EnemyFocusDropdown.SelectedIndex].Health * 0.5-2f).ToString();
            tabList[tabList.Count - 1].CharacterLeftLegBox.Text = Math.Round(statList[EnemyRankDropdown.SelectedIndex].focuses[EnemyFocusDropdown.SelectedIndex].Health * 0.5-2f).ToString();

            tabList[tabList.Count - 1].CharacterHeadValue = Convert.ToInt32(tabList[tabList.Count - 1].CharacterHeadBox.Text);
            tabList[tabList.Count - 1].CharacterChestValue = Convert.ToInt32(tabList[tabList.Count - 1].CharacterChestBox.Text);
            tabList[tabList.Count - 1].CharacterStomachValue = Convert.ToInt32(tabList[tabList.Count - 1].CharacterStomachBox.Text);
            tabList[tabList.Count - 1].CharacterRightArmValue = Convert.ToInt32(tabList[tabList.Count - 1].CharacterRightArmBox.Text);
            tabList[tabList.Count - 1].CharacterLeftArmValue = Convert.ToInt32(tabList[tabList.Count - 1].CharacterLeftArmBox.Text);
            tabList[tabList.Count - 1].CharacterRightLegValue = Convert.ToInt32(tabList[tabList.Count - 1].CharacterRightLegBox.Text);
            tabList[tabList.Count - 1].CharacterLeftLegValue = Convert.ToInt32(tabList[tabList.Count - 1].CharacterLeftLegBox.Text);

            tabList[tabList.Count - 1].EnemyNameLabel.Text = "Rank "+(EnemyRankDropdown.SelectedIndex + 1).ToString() + " " + (string)EnemyTypeDropdown.SelectedItem + ", Fokus: " + (string)EnemyFocusDropdown.SelectedItem;

            tabList[tabList.Count - 1].Text = (string)EnemyVariantDropdown.SelectedItem;
        }
            
        TabController.TabPages.Add(tabList[tabList.Count - 1]);
        int tabWidth = TabController.Width / TabController.TabPages.Count - 1;
        TabController.ItemSize = new Size(tabWidth, TabController.ItemSize.Height);
        TabController.SelectedIndex = TabController.TabPages.Count - 1;
    }

    private void FillBoxes()
    {
        if (CurrentMode == "Event")
        {
            TerrainEventDropdown.Items.Add("Ospecifik Terräng");
            for (int i = 0; i < terrainTypes.Count; i++)
            {
                TerrainEventDropdown.Items.Add(terrainTypes[i].Name);
            }
            TerrainEventDropdown.SelectedItem = "Ospecifik Terräng";

            EventTypeDropdown.Items.Add("Ospecifikt Event");
            EventTypeDropdown.Items.Add("Begränsat Event");
            EventTypeDropdown.SelectedItem = "Ospecifikt Event";
        }
        else if (CurrentMode == "Enemy")
        {
            EnemyRankDropdown.Items.Add("Vanlig");
            EnemyRankDropdown.Items.Add("Ovanlig");
            EnemyRankDropdown.Items.Add("Formidabel");
            EnemyRankDropdown.Items.Add("Sällsynt");
            EnemyRankDropdown.Items.Add("Mytisk");
            EnemyRankDropdown.SelectedItem = "Vanlig";

            EnemyFocusDropdown.Items.Add("Generell");
            EnemyFocusDropdown.Items.Add("Styrka");
            EnemyFocusDropdown.Items.Add("Tålighet");
            EnemyFocusDropdown.Items.Add("Intellekt");
            EnemyFocusDropdown.Items.Add("Psyke");
            EnemyFocusDropdown.Items.Add("Smidighet");
            EnemyFocusDropdown.SelectedItem = "Generell";

            for (int i = 0; i < enemyTypes.Count; i++)
            {
                EnemyTypeDropdown.Items.Add(enemyTypes[i].Name);
            }
            EnemyTypeDropdown.Text = "Välj Fiendetyp";

            EnemyTerrainDropdown.Items.Add("Ospecifik Terräng");
            for (int i = 0; i < terrainTypes.Count; i++)
            {
                EnemyTerrainDropdown.Items.Add(terrainTypes[i].Name);
            }
            EnemyTerrainDropdown.SelectedItem = "Ospecifik Terräng";
        }
    }

    // Enemy Generation
    private void EnemyTypeDropdown_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateVariantDropdown();
    }

    private void EnemyVariantDropdown_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateFocusDropdown();
    }

    private void EnemyTerrainDropdown_SelectedIndexChanged(object sender, EventArgs e)
    {
        //EnemyTypeDropdown.SelectedIndex = -1;
        EnemyTypeDropdown.Items.Clear();
        EnemyTypeDropdown.Text = "Välj Fiendetyp";

        EnemyVariantDropdown.Items.Clear();
        EnemyVariantDropdown.Text = "Välj Fiendevariant";

        EnemyFocusDropdown.SelectedItem = "Generell";
        EnemyRankDropdown.SelectedItem = "Vanlig";

        if ((string)EnemyTerrainDropdown.SelectedItem == "Ospecifik Terräng")
        {
            for (int i = 0; i < enemyTypes.Count; i++)
            {
                EnemyTypeDropdown.Items.Add(enemyTypes[i].Name);
            }
            return;
        }
        else
        {
            for (int i = 0; i < terrains.Count; i++)
            {
                if (terrains[i].Name == (string)EnemyTerrainDropdown.SelectedItem)
                {
                    for (int j = 0; j < terrains[i].Enemies.Count; j++)
                    {
                        EnemyTypeDropdown.Items.Add(terrains[i].Enemies[j].Name);
                    }
                }
            }
        }
    }

    private void EnemyTerrainButton_Click(object sender, EventArgs e)
    {
        if (enemyTypes.Count == 0)
        {
            return;
        }
        EnemyTypeDropdown.SelectedIndex = Rand.Next(0, EnemyTypeDropdown.Items.Count);
        UpdateVariantDropdown();
        
        int probability = 0;
        int index = 0;
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].name == (string)EnemyTypeDropdown.SelectedItem)
            {
                probability = enemies[i].variantList[enemies[i].variantList.Count - 1].Chance;
                index = i;
                break;
            }
        }
        probability = Rand.Next(1, probability);
        for (int i = 0; i < enemies[index].variantList.Count; i++)
        {
            if (probability <= enemies[index].variantList[i].Chance)
            {
                EnemyVariantDropdown.SelectedItem = enemies[index].variantList[i].Variant;
                break;
            }
        }
        UpdateFocusDropdown();
    }

    private void CreateEnemyButton_Click(object sender, EventArgs e)
    {
        CreateEnemyTab();
    }

    private void RemoveEnemyButton_Click(object sender, EventArgs e)
    {
        if (TabController.TabPages.Count > 0)
        {
            tabList.RemoveAt(TabController.SelectedIndex);
            TabController.TabPages.Remove(TabController.SelectedTab);
        }
        if (TabController.TabPages.Count > 0)
        {
            int tabWidth = TabController.Width / TabController.TabPages.Count - 1;
            TabController.ItemSize = new Size(tabWidth, TabController.ItemSize.Height);
        }
    }

    //Enemy HP
    private void CharacterHeadBox_ValueChanged(object sender, EventArgs e)
    {
        int newValue = Convert.ToInt32(tabList[TabController.SelectedIndex].CharacterHeadBox.Value);
        int newTotalValue = Convert.ToInt32(tabList[TabController.SelectedIndex].CharacterTotalBox.Value);

        if (tabList[TabController.SelectedIndex].CharacterTotalBox.Value == 0)
        {
            tabList[TabController.SelectedIndex].CharacterHeadValue = newValue;
            return;
        }

        tabList[TabController.SelectedIndex].CharacterTotalBox.Value = Convert.ToDecimal(newTotalValue - (tabList[TabController.SelectedIndex].CharacterHeadValue - newValue));

        tabList[TabController.SelectedIndex].CharacterHeadValue = newValue;
    }

    private void CharacterStomachBox_ValueChanged(object sender, EventArgs e)
    {
        int newValue = Convert.ToInt32(tabList[TabController.SelectedIndex].CharacterStomachBox.Value);
        int newTotalValue = Convert.ToInt32(tabList[TabController.SelectedIndex].CharacterTotalBox.Value);

        if (tabList[TabController.SelectedIndex].CharacterTotalBox.Value == 0)
        {
            tabList[TabController.SelectedIndex].CharacterStomachValue = newValue;
            return;
        }

        tabList[TabController.SelectedIndex].CharacterTotalBox.Value = Convert.ToDecimal(newTotalValue - (tabList[TabController.SelectedIndex].CharacterStomachValue - newValue));

        tabList[TabController.SelectedIndex].CharacterStomachValue = newValue;
    }

    private void CharacterRightArmBox_ValueChanged(object sender, EventArgs e)
    {
        int newValue = Convert.ToInt32(tabList[TabController.SelectedIndex].CharacterRightArmBox.Value);
        int newTotalValue = Convert.ToInt32(tabList[TabController.SelectedIndex].CharacterTotalBox.Value);

        if (tabList[TabController.SelectedIndex].CharacterTotalBox.Value == 0)
        {
            tabList[TabController.SelectedIndex].CharacterRightArmValue = newValue;
            return;
        }

        tabList[TabController.SelectedIndex].CharacterTotalBox.Value = Convert.ToDecimal(newTotalValue - (tabList[TabController.SelectedIndex].CharacterRightArmValue - newValue));

        tabList[TabController.SelectedIndex].CharacterRightArmValue = newValue;
    }

    private void CharacterRightLegBox_ValueChanged(object sender, EventArgs e)
    {
        int newValue = Convert.ToInt32(tabList[TabController.SelectedIndex].CharacterRightLegBox.Value);
        int newTotalValue = Convert.ToInt32(tabList[TabController.SelectedIndex].CharacterTotalBox.Value);

        if (tabList[TabController.SelectedIndex].CharacterTotalBox.Value == 0)
        {
            tabList[TabController.SelectedIndex].CharacterRightLegValue = newValue;
            return;
        }

        tabList[TabController.SelectedIndex].CharacterTotalBox.Value = Convert.ToDecimal(newTotalValue - (tabList[TabController.SelectedIndex].CharacterRightLegValue - newValue));

        tabList[TabController.SelectedIndex].CharacterRightLegValue = newValue;
    }

    private void CharacterChestBox_ValueChanged(object sender, EventArgs e)
    {
        int newValue = Convert.ToInt32(tabList[TabController.SelectedIndex].CharacterChestBox.Value);
        int newTotalValue = Convert.ToInt32(tabList[TabController.SelectedIndex].CharacterTotalBox.Value);

        if (tabList[TabController.SelectedIndex].CharacterTotalBox.Value == 0)
        {
            tabList[TabController.SelectedIndex].CharacterChestValue = newValue;
            return;
        }

        tabList[TabController.SelectedIndex].CharacterTotalBox.Value = Convert.ToDecimal(newTotalValue - (tabList[TabController.SelectedIndex].CharacterChestValue - newValue));

        tabList[TabController.SelectedIndex].CharacterChestValue = newValue;
    }

    private void CharacterLeftArmBox_ValueChanged(object sender, EventArgs e)
    {
        int newValue = Convert.ToInt32(tabList[TabController.SelectedIndex].CharacterLeftArmBox.Value);
        int newTotalValue = Convert.ToInt32(tabList[TabController.SelectedIndex].CharacterTotalBox.Value);

        if (tabList[TabController.SelectedIndex].CharacterTotalBox.Value == 0)
        {
            tabList[TabController.SelectedIndex].CharacterLeftArmValue = newValue;
            return;
        }

        tabList[TabController.SelectedIndex].CharacterTotalBox.Value = Convert.ToDecimal(newTotalValue - (tabList[TabController.SelectedIndex].CharacterLeftArmValue - newValue));

        tabList[TabController.SelectedIndex].CharacterLeftArmValue = newValue;
    }

    private void CharacterLeftLegBox_ValueChanged(object sender, EventArgs e)
    {
        int newValue = Convert.ToInt32(tabList[TabController.SelectedIndex].CharacterLeftLegBox.Value);
        int newTotalValue = Convert.ToInt32(tabList[TabController.SelectedIndex].CharacterTotalBox.Value);

        if (tabList[TabController.SelectedIndex].CharacterTotalBox.Value == 0)
        {
            tabList[TabController.SelectedIndex].CharacterLeftLegValue = newValue;
            return;
        }

        tabList[TabController.SelectedIndex].CharacterTotalBox.Value = Convert.ToDecimal(newTotalValue - (tabList[TabController.SelectedIndex].CharacterLeftLegValue - newValue));

        tabList[TabController.SelectedIndex].CharacterLeftLegValue = newValue;
    }

    private void Box_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            e.Handled = true;
    }

    // Update Dropdowns
    private void UpdateVariantDropdown()
    {
        if (enemies == null || enemies.Count == 0) { return; }

        //EnemyVariantDropdown.SelectedIndex = -1;
        EnemyVariantDropdown.Items.Clear();
        EnemyVariantDropdown.Text = "Välj Fiendevariant";

        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].name == (string)EnemyTypeDropdown.SelectedItem)
            {
                for (int j = 0; j < enemies[i].variantList.Count; j++)
                {
                    EnemyVariantDropdown.Items.Add(enemies[i].variantList[j].Variant);
                }
                break;
            }
        }
    }

    private void UpdateFocusDropdown()
    {
        if (enemies == null || enemies.Count == 0) { return; }

        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].name == (string)EnemyTypeDropdown.SelectedItem)
            {
                for (int j = 0; j < enemies[i].variantList.Count; j++)
                {
                    if (enemies[i].variantList[j].Variant == (string)EnemyVariantDropdown.SelectedItem)
                    {
                        EnemyFocusDropdown.SelectedItem = enemies[i].variantList[j].Attributefocus;
                        break;
                    }
                }
                break;
            }
        }
    }
    #endregion

    #region EventMode
    private void CreateEventButton_Click(object sender, EventArgs e)
    {

    }

    private void EventTypeDropdown_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((string)EventTypeDropdown.SelectedItem == "Ospecifikt Event")
        {
            NPCEventCheckBox.Checked = false;
            LocationEventCheckBox.Checked = false;
            NPCEventCheckBox.Enabled = false;
            LocationEventCheckBox.Enabled = false;
        }
        else
        {
            NPCEventCheckBox.Enabled = true;
            LocationEventCheckBox.Enabled = true;
        }
    }
    #endregion
}
