using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EnemyPage : System.Windows.Forms.TabPage
{
    public System.Windows.Forms.NumericUpDown AgilityBox;
    public System.Windows.Forms.NumericUpDown MindBox;
    public System.Windows.Forms.NumericUpDown IntellectBox;
    public System.Windows.Forms.NumericUpDown ToughnessBox;
    public System.Windows.Forms.NumericUpDown StrengthBox;
    public System.Windows.Forms.Label StrengthLabel;
    public System.Windows.Forms.Label AgilityLabel;
    public System.Windows.Forms.Label MindLabel;
    public System.Windows.Forms.Label IntellectLabel;
    public System.Windows.Forms.Label ToughnessLabel;
    public System.Windows.Forms.Label AgilityValueLabel;
    public System.Windows.Forms.Label MindValueLabel;
    public System.Windows.Forms.Label IntellectValueLabel;
    public System.Windows.Forms.Label ToughnessValueLabel;
    public System.Windows.Forms.Label StrengthValueLabel;
    public System.Windows.Forms.Label DamageValueLabel;
    public System.Windows.Forms.TextBox DamageBox;
    public System.Windows.Forms.Label DamageLabel;
    public System.Windows.Forms.PictureBox CharacterImage;
    public System.Windows.Forms.NumericUpDown CharacterChestBox;
    public System.Windows.Forms.NumericUpDown CharacterStomachBox;
    public System.Windows.Forms.NumericUpDown CharacterHeadBox;
    public System.Windows.Forms.NumericUpDown CharacterLeftArmBox;
    public System.Windows.Forms.NumericUpDown CharacterLeftLegBox;
    public System.Windows.Forms.NumericUpDown CharacterRightArmBox;
    public System.Windows.Forms.NumericUpDown CharacterRightLegBox;
    public System.Windows.Forms.NumericUpDown CharacterTotalBox;
    public System.Windows.Forms.Label CharacterHeadLabel;
    public System.Windows.Forms.Label EnemyNameLabel;
    public System.Windows.Forms.Label CharacterChestLabel;
    public System.Windows.Forms.Label CharacterTotalLabel;
    public System.Windows.Forms.Label CharacterStomachLabel;
    public System.Windows.Forms.Label CharacterLeftLegLabel;
    public System.Windows.Forms.Label CharacterRightLegLabel;
    public System.Windows.Forms.Label CharacterLeftArmLabel;
    public System.Windows.Forms.Label CharacterRightArmLabel;

    public int CharacterHeadValue;
    public int CharacterChestValue;
    public int CharacterTotalValue;
    public int CharacterStomachValue;
    public int CharacterLeftLegValue;
    public int CharacterRightLegValue;
    public int CharacterLeftArmValue;
    public int CharacterRightArmValue;

    public EnemyPage()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppForm));
        this.CharacterChestLabel = new System.Windows.Forms.Label();
        this.CharacterTotalLabel = new System.Windows.Forms.Label();
        this.CharacterStomachLabel = new System.Windows.Forms.Label();
        this.CharacterLeftLegLabel = new System.Windows.Forms.Label();
        this.CharacterRightLegLabel = new System.Windows.Forms.Label();
        this.CharacterLeftArmLabel = new System.Windows.Forms.Label();
        this.CharacterRightArmLabel = new System.Windows.Forms.Label();
        this.CharacterHeadLabel = new System.Windows.Forms.Label();
        this.EnemyNameLabel = new System.Windows.Forms.Label();
        this.CharacterChestBox = new System.Windows.Forms.NumericUpDown();
        this.CharacterStomachBox = new System.Windows.Forms.NumericUpDown();
        this.CharacterHeadBox = new System.Windows.Forms.NumericUpDown();
        this.CharacterLeftArmBox = new System.Windows.Forms.NumericUpDown();
        this.CharacterLeftLegBox = new System.Windows.Forms.NumericUpDown();
        this.CharacterRightArmBox = new System.Windows.Forms.NumericUpDown();
        this.CharacterRightLegBox = new System.Windows.Forms.NumericUpDown();
        this.CharacterTotalBox = new System.Windows.Forms.NumericUpDown();
        this.CharacterImage = new System.Windows.Forms.PictureBox();
        this.AgilityValueLabel = new System.Windows.Forms.Label();
        this.AgilityLabel = new System.Windows.Forms.Label();
        this.MindValueLabel = new System.Windows.Forms.Label();
        this.MindLabel = new System.Windows.Forms.Label();
        this.IntellectValueLabel = new System.Windows.Forms.Label();
        this.IntellectLabel = new System.Windows.Forms.Label();
        this.ToughnessValueLabel = new System.Windows.Forms.Label();
        this.ToughnessLabel = new System.Windows.Forms.Label();
        this.StrengthValueLabel = new System.Windows.Forms.Label();
        this.StrengthLabel = new System.Windows.Forms.Label();
        this.AgilityBox = new System.Windows.Forms.NumericUpDown();
        this.MindBox = new System.Windows.Forms.NumericUpDown();
        this.IntellectBox = new System.Windows.Forms.NumericUpDown();
        this.ToughnessBox = new System.Windows.Forms.NumericUpDown();
        this.StrengthBox = new System.Windows.Forms.NumericUpDown();
        this.DamageLabel = new System.Windows.Forms.Label();
        this.DamageBox = new System.Windows.Forms.TextBox();
        this.DamageValueLabel = new System.Windows.Forms.Label();

        CharacterHeadValue = 0;
        CharacterChestValue = 0;
        CharacterTotalValue = 0;
        CharacterStomachValue = 0;
        CharacterLeftLegValue = 0;
        CharacterRightLegValue = 0;
        CharacterLeftArmValue = 0;
        CharacterRightArmValue = 0;

        ((System.ComponentModel.ISupportInitialize)(this.CharacterImage)).BeginInit();
        this.SuspendLayout();
        // 
        // Page
        // 
        this.Controls.Add(this.CharacterChestLabel);
        this.Controls.Add(this.CharacterTotalLabel);
        this.Controls.Add(this.CharacterStomachLabel);
        this.Controls.Add(this.CharacterLeftLegLabel);
        this.Controls.Add(this.CharacterRightLegLabel);
        this.Controls.Add(this.CharacterLeftArmLabel);
        this.Controls.Add(this.CharacterRightArmLabel);
        this.Controls.Add(this.CharacterHeadLabel);
        this.Controls.Add(this.EnemyNameLabel);
        this.Controls.Add(this.CharacterChestBox);
        this.Controls.Add(this.CharacterStomachBox);
        this.Controls.Add(this.CharacterHeadBox);
        this.Controls.Add(this.CharacterLeftArmBox);
        this.Controls.Add(this.CharacterLeftLegBox);
        this.Controls.Add(this.CharacterRightArmBox);
        this.Controls.Add(this.CharacterRightLegBox);
        this.Controls.Add(this.CharacterTotalBox);
        this.Controls.Add(this.CharacterImage);
        this.Controls.Add(this.AgilityValueLabel);
        this.Controls.Add(this.AgilityLabel);
        this.Controls.Add(this.MindValueLabel);
        this.Controls.Add(this.MindLabel);
        this.Controls.Add(this.IntellectValueLabel);
        this.Controls.Add(this.IntellectLabel);
        this.Controls.Add(this.ToughnessValueLabel);
        this.Controls.Add(this.ToughnessLabel);
        this.Controls.Add(this.StrengthValueLabel);
        this.Controls.Add(this.StrengthLabel);
        this.Controls.Add(this.AgilityBox);
        this.Controls.Add(this.MindBox);
        this.Controls.Add(this.IntellectBox);
        this.Controls.Add(this.ToughnessBox);
        this.Controls.Add(this.StrengthBox);
        this.Controls.Add(this.DamageValueLabel);
        this.Controls.Add(this.DamageBox);
        this.Controls.Add(this.DamageLabel);
        this.Location = new System.Drawing.Point(4, 22);
        this.Name = "Enemy1";
        this.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
        this.Size = new System.Drawing.Size(492, 213);
        this.TabIndex = 0;
        this.Text = "Fiende 1";
        this.UseVisualStyleBackColor = true;
        // 
        // CharacterChestLabel
        // 
        this.CharacterChestLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.CharacterChestLabel.AutoSize = true;
        this.CharacterChestLabel.Location = new System.Drawing.Point(435, 52);
        this.CharacterChestLabel.Name = "CharacterChestLabel";
        this.CharacterChestLabel.Size = new System.Drawing.Size(52, 13);
        this.CharacterChestLabel.TabIndex = 30;
        this.CharacterChestLabel.Text = "Bröstkorg";
        // 
        // CharacterTotalLabel
        // 
        this.CharacterTotalLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.CharacterTotalLabel.AutoSize = true;
        this.CharacterTotalLabel.Location = new System.Drawing.Point(316, 188);
        this.CharacterTotalLabel.Name = "CharacterTotalLabel";
        this.CharacterTotalLabel.Size = new System.Drawing.Size(48, 13);
        this.CharacterTotalLabel.TabIndex = 29;
        this.CharacterTotalLabel.Text = "Total KP";
        // 
        // CharacterStomachLabel
        // 
        this.CharacterStomachLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.CharacterStomachLabel.AutoSize = true;
        this.CharacterStomachLabel.Location = new System.Drawing.Point(208, 52);
        this.CharacterStomachLabel.Name = "CharacterStomachLabel";
        this.CharacterStomachLabel.Size = new System.Drawing.Size(34, 13);
        this.CharacterStomachLabel.TabIndex = 28;
        this.CharacterStomachLabel.Text = "Mage";
        this.CharacterStomachLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
        // 
        // CharacterLeftLegLabel
        // 
        this.CharacterLeftLegLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.CharacterLeftLegLabel.AutoSize = true;
        this.CharacterLeftLegLabel.Location = new System.Drawing.Point(435, 150);
        this.CharacterLeftLegLabel.Name = "CharacterLeftLegLabel";
        this.CharacterLeftLegLabel.Size = new System.Drawing.Size(39, 13);
        this.CharacterLeftLegLabel.TabIndex = 27;
        this.CharacterLeftLegLabel.Text = "V. Ben";
        // 
        // CharacterRightLegLabel
        // 
        this.CharacterRightLegLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.CharacterRightLegLabel.AutoSize = true;
        this.CharacterRightLegLabel.Location = new System.Drawing.Point(208, 150);
        this.CharacterRightLegLabel.Name = "CharacterRightLegLabel";
        this.CharacterRightLegLabel.Size = new System.Drawing.Size(40, 13);
        this.CharacterRightLegLabel.TabIndex = 26;
        this.CharacterRightLegLabel.Text = "H. Ben";
        this.CharacterRightLegLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
        // 
        // CharacterLeftArmLabel
        // 
        this.CharacterLeftArmLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.CharacterLeftArmLabel.AutoSize = true;
        this.CharacterLeftArmLabel.Location = new System.Drawing.Point(435, 102);
        this.CharacterLeftArmLabel.Name = "CharacterLeftArmLabel";
        this.CharacterLeftArmLabel.Size = new System.Drawing.Size(38, 13);
        this.CharacterLeftArmLabel.TabIndex = 25;
        this.CharacterLeftArmLabel.Text = "V. Arm";
        // 
        // CharacterRightArmLabel
        // 
        this.CharacterRightArmLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.CharacterRightArmLabel.AutoSize = true;
        this.CharacterRightArmLabel.Location = new System.Drawing.Point(208, 102);
        this.CharacterRightArmLabel.Name = "CharacterRightArmLabel";
        this.CharacterRightArmLabel.Size = new System.Drawing.Size(39, 13);
        this.CharacterRightArmLabel.TabIndex = 24;
        this.CharacterRightArmLabel.Text = "H. Arm";
        this.CharacterRightArmLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
        // 
        // CharacterHeadLabel
        // 
        this.CharacterHeadLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.CharacterHeadLabel.AutoSize = true;
        this.CharacterHeadLabel.Location = new System.Drawing.Point(320, 12);
        this.CharacterHeadLabel.Name = "CharacterHeadLabel";
        this.CharacterHeadLabel.Size = new System.Drawing.Size(39, 13);
        this.CharacterHeadLabel.TabIndex = 23;
        this.CharacterHeadLabel.Text = "Huvud";
        // 
        // EnemyNameLabel
        // 
        this.EnemyNameLabel.Location = new System.Drawing.Point(9, 12);
        this.EnemyNameLabel.Name = "EnemyNameLabel";
        this.EnemyNameLabel.Size = new System.Drawing.Size(172, 13);
        this.EnemyNameLabel.TabIndex = 22;
        this.EnemyNameLabel.Text = "Namn";
        this.EnemyNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // CharacterChestBox
        // 
        this.CharacterChestBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.CharacterChestBox.Location = new System.Drawing.Point(385, 49);
        this.CharacterChestBox.Name = "CharacterChestBox";
        this.CharacterChestBox.Size = new System.Drawing.Size(47, 20);
        this.CharacterChestBox.TabIndex = 19;
        this.CharacterChestBox.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        // 
        // CharacterStomachBox
        // 
        this.CharacterStomachBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.CharacterStomachBox.Location = new System.Drawing.Point(248, 49);
        this.CharacterStomachBox.Name = "CharacterStomachBox";
        this.CharacterStomachBox.Size = new System.Drawing.Size(47, 20);
        this.CharacterStomachBox.TabIndex = 18;
        this.CharacterStomachBox.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        // 
        // CharacterHeadBox
        // 
        this.CharacterHeadBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.CharacterHeadBox.Location = new System.Drawing.Point(316, 28);
        this.CharacterHeadBox.Name = "CharacterHeadBox";
        this.CharacterHeadBox.Size = new System.Drawing.Size(47, 20);
        this.CharacterHeadBox.TabIndex = 17;
        this.CharacterHeadBox.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        // 
        // CharacterLeftArmBox
        // 
        this.CharacterLeftArmBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.CharacterLeftArmBox.Location = new System.Drawing.Point(385, 99);
        this.CharacterLeftArmBox.Name = "CharacterLeftArmBox";
        this.CharacterLeftArmBox.Size = new System.Drawing.Size(47, 20);
        this.CharacterLeftArmBox.TabIndex = 16;
        this.CharacterLeftArmBox.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        // 
        // CharacterLeftLegBox
        // 
        this.CharacterLeftLegBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.CharacterLeftLegBox.Location = new System.Drawing.Point(385, 146);
        this.CharacterLeftLegBox.Name = "CharacterLeftLegBox";
        this.CharacterLeftLegBox.Size = new System.Drawing.Size(47, 20);
        this.CharacterLeftLegBox.TabIndex = 15;
        this.CharacterLeftLegBox.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        // 
        // CharacterRightArmBox
        // 
        this.CharacterRightArmBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.CharacterRightArmBox.Location = new System.Drawing.Point(248, 99);
        this.CharacterRightArmBox.Name = "CharacterRightArmBox";
        this.CharacterRightArmBox.Size = new System.Drawing.Size(47, 20);
        this.CharacterRightArmBox.TabIndex = 14;
        this.CharacterRightArmBox.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        // 
        // CharacterRightLegBox
        // 
        this.CharacterRightLegBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.CharacterRightLegBox.Location = new System.Drawing.Point(248, 147);
        this.CharacterRightLegBox.Name = "CharacterRightLegBox";
        this.CharacterRightLegBox.Size = new System.Drawing.Size(47, 20);
        this.CharacterRightLegBox.TabIndex = 13;
        this.CharacterRightLegBox.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        // 
        // CharacterTotalBox
        // 
        this.CharacterTotalBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.CharacterTotalBox.Location = new System.Drawing.Point(316, 165);
        this.CharacterTotalBox.Name = "CharacterTotalBox";
        this.CharacterTotalBox.Size = new System.Drawing.Size(47, 20);
        this.CharacterTotalBox.TabIndex = 12;
        this.CharacterTotalBox.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        // 
        // CharacterImage
        // 
        this.CharacterImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.CharacterImage.Image = global::Exopias_Hemligheter.Properties.Resources.fiende;
        this.CharacterImage.Location = new System.Drawing.Point(301, 54);
        this.CharacterImage.Name = "CharacterImage";
        this.CharacterImage.Size = new System.Drawing.Size(78, 105);
        this.CharacterImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.CharacterImage.TabIndex = 5;
        this.CharacterImage.TabStop = false;
        // 
        // AgilityValueLabel
        // 
        this.AgilityValueLabel.AutoSize = true;
        this.AgilityValueLabel.Location = new System.Drawing.Point(137, 147);
        this.AgilityValueLabel.Name = "AgilityValueLabel";
        this.AgilityValueLabel.Size = new System.Drawing.Size(53, 13);
        this.AgilityValueLabel.TabIndex = 9;
        this.AgilityValueLabel.Text = "Smidighet";
        // 
        // AgilityLabel
        // 
        this.AgilityLabel.AutoSize = true;
        this.AgilityLabel.Location = new System.Drawing.Point(6, 147);
        this.AgilityLabel.Name = "AgilityLabel";
        this.AgilityLabel.Size = new System.Drawing.Size(53, 13);
        this.AgilityLabel.TabIndex = 9;
        this.AgilityLabel.Text = "Smidighet";
        // 
        // MindValueLabel
        // 
        this.MindValueLabel.AutoSize = true;
        this.MindValueLabel.Location = new System.Drawing.Point(137, 121);
        this.MindValueLabel.Name = "MindValueLabel";
        this.MindValueLabel.Size = new System.Drawing.Size(36, 13);
        this.MindValueLabel.TabIndex = 8;
        this.MindValueLabel.Text = "Psyke";
        // 
        // MindLabel
        // 
        this.MindLabel.AutoSize = true;
        this.MindLabel.Location = new System.Drawing.Point(6, 121);
        this.MindLabel.Name = "MindLabel";
        this.MindLabel.Size = new System.Drawing.Size(36, 13);
        this.MindLabel.TabIndex = 8;
        this.MindLabel.Text = "Psyke";
        // 
        // IntellectValueLabel
        // 
        this.IntellectValueLabel.AutoSize = true;
        this.IntellectValueLabel.Location = new System.Drawing.Point(137, 95);
        this.IntellectValueLabel.Name = "IntellectValueLabel";
        this.IntellectValueLabel.Size = new System.Drawing.Size(44, 13);
        this.IntellectValueLabel.TabIndex = 7;
        this.IntellectValueLabel.Text = "Intellekt";
        // 
        // IntellectLabel
        // 
        this.IntellectLabel.AutoSize = true;
        this.IntellectLabel.Location = new System.Drawing.Point(6, 95);
        this.IntellectLabel.Name = "IntellectLabel";
        this.IntellectLabel.Size = new System.Drawing.Size(44, 13);
        this.IntellectLabel.TabIndex = 7;
        this.IntellectLabel.Text = "Intellekt";
        // 
        // ToughnessValueLabel
        // 
        this.ToughnessValueLabel.AutoSize = true;
        this.ToughnessValueLabel.Location = new System.Drawing.Point(137, 69);
        this.ToughnessValueLabel.Name = "ToughnessValueLabel";
        this.ToughnessValueLabel.Size = new System.Drawing.Size(45, 13);
        this.ToughnessValueLabel.TabIndex = 6;
        this.ToughnessValueLabel.Text = "Tålighet";
        // 
        // ToughnessLabel
        // 
        this.ToughnessLabel.AutoSize = true;
        this.ToughnessLabel.Location = new System.Drawing.Point(6, 69);
        this.ToughnessLabel.Name = "ToughnessLabel";
        this.ToughnessLabel.Size = new System.Drawing.Size(45, 13);
        this.ToughnessLabel.TabIndex = 6;
        this.ToughnessLabel.Text = "Tålighet";
        // 
        // StrengthValueLabel
        // 
        this.StrengthValueLabel.AutoSize = true;
        this.StrengthValueLabel.Location = new System.Drawing.Point(137, 43);
        this.StrengthValueLabel.Name = "StrengthValueLabel";
        this.StrengthValueLabel.Size = new System.Drawing.Size(37, 13);
        this.StrengthValueLabel.TabIndex = 5;
        this.StrengthValueLabel.Text = "Styrka";
        // 
        // StrengthLabel
        // 
        this.StrengthLabel.AutoSize = true;
        this.StrengthLabel.Location = new System.Drawing.Point(6, 43);
        this.StrengthLabel.Name = "StrengthLabel";
        this.StrengthLabel.Size = new System.Drawing.Size(37, 13);
        this.StrengthLabel.TabIndex = 5;
        this.StrengthLabel.Text = "Styrka";
        // 
        // AgilityBox
        // 
        this.AgilityBox.Location = new System.Drawing.Point(68, 144);
        this.AgilityBox.Name = "AgilityBox";
        this.AgilityBox.Size = new System.Drawing.Size(53, 20);
        this.AgilityBox.TabIndex = 4;
        this.AgilityBox.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        // 
        // MindBox
        // 
        this.MindBox.Location = new System.Drawing.Point(68, 118);
        this.MindBox.Name = "MindBox";
        this.MindBox.Size = new System.Drawing.Size(53, 20);
        this.MindBox.TabIndex = 3;
        this.MindBox.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        // 
        // IntellectBox
        // 
        this.IntellectBox.Location = new System.Drawing.Point(68, 92);
        this.IntellectBox.Name = "IntellectBox";
        this.IntellectBox.Size = new System.Drawing.Size(53, 20);
        this.IntellectBox.TabIndex = 2;
        this.IntellectBox.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        // 
        // ToughnessBox
        // 
        this.ToughnessBox.Location = new System.Drawing.Point(68, 66);
        this.ToughnessBox.Name = "ToughnessBox";
        this.ToughnessBox.Size = new System.Drawing.Size(53, 20);
        this.ToughnessBox.TabIndex = 1;
        this.ToughnessBox.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        // 
        // StrengthBox
        // 
        this.StrengthBox.Location = new System.Drawing.Point(68, 40);
        this.StrengthBox.Name = "StrengthBox";
        this.StrengthBox.Size = new System.Drawing.Size(53, 20);
        this.StrengthBox.TabIndex = 0;
        this.StrengthBox.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        // 
        // DamageValueLabel
        // 
        this.DamageValueLabel.AutoSize = true;
        this.DamageValueLabel.Location = new System.Drawing.Point(137, 173);
        this.DamageValueLabel.Name = "DamageValueLabel";
        this.DamageValueLabel.Size = new System.Drawing.Size(38, 13);
        this.DamageValueLabel.TabIndex = 33;
        this.DamageValueLabel.Text = "Skada";
        // 
        // DamageBox
        // 
        this.DamageBox.Location = new System.Drawing.Point(68, 170);
        this.DamageBox.Name = "DamageBox";
        this.DamageBox.Size = new System.Drawing.Size(53, 20);
        this.DamageBox.TabIndex = 32;
        // 
        // DamageLabel
        // 
        this.DamageLabel.AutoSize = true;
        this.DamageLabel.Location = new System.Drawing.Point(6, 173);
        this.DamageLabel.Name = "DamageLabel";
        this.DamageLabel.Size = new System.Drawing.Size(38, 13);
        this.DamageLabel.TabIndex = 31;
        this.DamageLabel.Text = "Skada";
        //
        // AppForm
        //
        ((System.ComponentModel.ISupportInitialize)(this.CharacterImage)).EndInit();
        this.ResumeLayout(false);
    }
}
