namespace ParkhausSW
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Dashboard = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ausfahrt_code_tb = new System.Windows.Forms.TextBox();
            this.ausfahrt_tickets_cb = new System.Windows.Forms.ComboBox();
            this.ausfahrt_code_eingeben_btn = new System.Windows.Forms.Button();
            this.ausfahrt_ausgabe_tb = new System.Windows.Forms.TextBox();
            this.ticket_scannen_btn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.kassenautomat_tickets_cb = new System.Windows.Forms.ComboBox();
            this.kassenautomat_ticket_bezahlen_btn = new System.Windows.Forms.Button();
            this.kassenautomat_ausgabe_tb = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.einfahrt_code_tb = new System.Windows.Forms.TextBox();
            this.einfahrt_code_eingeben_btn = new System.Windows.Forms.Button();
            this.einfahrt_ticket_ziehen_btn = new System.Windows.Forms.Button();
            this.einfahrt_ausgabe_tb = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dashboard_flp = new System.Windows.Forms.FlowLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.gesamtauslastung_lbl = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dauermieter_loeschen_cb = new System.Windows.Forms.ComboBox();
            this.dauermieter_loeschen_btn = new System.Windows.Forms.Button();
            this.dauermieter_anzeigen_btn = new System.Windows.Forms.Button();
            this.dauermieter_anzeigen_dgv = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.dauermieter_parkplatz_cb = new System.Windows.Forms.ComboBox();
            this.dauermieter_vertragsende_dtp = new System.Windows.Forms.DateTimePicker();
            this.dauermieter_bezahlt_cb = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dauermieter_zugangscode_tb = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dauermieter_vorname_tb = new System.Windows.Forms.TextBox();
            this.dauermieter_name_tb = new System.Windows.Forms.TextBox();
            this.dauermieter_anlegen_btn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.umsatzstatistik_gb = new System.Windows.Forms.GroupBox();
            this.report_generieren_btn = new System.Windows.Forms.Button();
            this.umsatz_monat_jahr_cb = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tarif_verwalten_gb = new System.Windows.Forms.GroupBox();
            this.tarif_verwalten_speichern_btn = new System.Windows.Forms.Button();
            this.tagespauschale_preis_nud = new System.Windows.Forms.NumericUpDown();
            this.tarif_preis_15_min_nud = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.parkhauskonfiguration_gb = new System.Windows.Forms.GroupBox();
            this.parkhauskonfiguration_speichern_btn = new System.Windows.Forms.Button();
            this.parkhauskonfiguration_plaetze_nud = new System.Windows.Forms.NumericUpDown();
            this.parkhauskonfiguration_stockwerke_nud = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.nachttarif_preis_15_min_nud = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.tarif_wochenende_nud = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.feiertag_aktiv_cb = new System.Windows.Forms.CheckBox();
            this.Dashboard.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dauermieter_anzeigen_dgv)).BeginInit();
            this.umsatzstatistik_gb.SuspendLayout();
            this.tarif_verwalten_gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tagespauschale_preis_nud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarif_preis_15_min_nud)).BeginInit();
            this.parkhauskonfiguration_gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parkhauskonfiguration_plaetze_nud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parkhauskonfiguration_stockwerke_nud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nachttarif_preis_15_min_nud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarif_wochenende_nud)).BeginInit();
            this.SuspendLayout();
            // 
            // Dashboard
            // 
            this.Dashboard.Controls.Add(this.tabPage1);
            this.Dashboard.Controls.Add(this.tabPage2);
            this.Dashboard.Controls.Add(this.tabPage3);
            this.Dashboard.Location = new System.Drawing.Point(12, 12);
            this.Dashboard.Name = "Dashboard";
            this.Dashboard.SelectedIndex = 0;
            this.Dashboard.Size = new System.Drawing.Size(1226, 709);
            this.Dashboard.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1218, 683);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Hardware";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ausfahrt_code_tb);
            this.groupBox3.Controls.Add(this.ausfahrt_tickets_cb);
            this.groupBox3.Controls.Add(this.ausfahrt_code_eingeben_btn);
            this.groupBox3.Controls.Add(this.ausfahrt_ausgabe_tb);
            this.groupBox3.Controls.Add(this.ticket_scannen_btn);
            this.groupBox3.Location = new System.Drawing.Point(806, 66);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(381, 547);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ausfahrt";
            // 
            // ausfahrt_code_tb
            // 
            this.ausfahrt_code_tb.Location = new System.Drawing.Point(124, 441);
            this.ausfahrt_code_tb.Name = "ausfahrt_code_tb";
            this.ausfahrt_code_tb.Size = new System.Drawing.Size(145, 20);
            this.ausfahrt_code_tb.TabIndex = 5;
            // 
            // ausfahrt_tickets_cb
            // 
            this.ausfahrt_tickets_cb.FormattingEnabled = true;
            this.ausfahrt_tickets_cb.Location = new System.Drawing.Point(124, 263);
            this.ausfahrt_tickets_cb.Name = "ausfahrt_tickets_cb";
            this.ausfahrt_tickets_cb.Size = new System.Drawing.Size(145, 21);
            this.ausfahrt_tickets_cb.TabIndex = 7;
            // 
            // ausfahrt_code_eingeben_btn
            // 
            this.ausfahrt_code_eingeben_btn.Location = new System.Drawing.Point(124, 399);
            this.ausfahrt_code_eingeben_btn.Name = "ausfahrt_code_eingeben_btn";
            this.ausfahrt_code_eingeben_btn.Size = new System.Drawing.Size(145, 36);
            this.ausfahrt_code_eingeben_btn.TabIndex = 4;
            this.ausfahrt_code_eingeben_btn.Text = "Code eingeben";
            this.ausfahrt_code_eingeben_btn.UseVisualStyleBackColor = true;
            this.ausfahrt_code_eingeben_btn.Click += new System.EventHandler(this.ausfahrt_code_eingeben_btn_Click);
            // 
            // ausfahrt_ausgabe_tb
            // 
            this.ausfahrt_ausgabe_tb.Location = new System.Drawing.Point(82, 79);
            this.ausfahrt_ausgabe_tb.Multiline = true;
            this.ausfahrt_ausgabe_tb.Name = "ausfahrt_ausgabe_tb";
            this.ausfahrt_ausgabe_tb.ReadOnly = true;
            this.ausfahrt_ausgabe_tb.Size = new System.Drawing.Size(230, 102);
            this.ausfahrt_ausgabe_tb.TabIndex = 2;
            // 
            // ticket_scannen_btn
            // 
            this.ticket_scannen_btn.Location = new System.Drawing.Point(124, 300);
            this.ticket_scannen_btn.Name = "ticket_scannen_btn";
            this.ticket_scannen_btn.Size = new System.Drawing.Size(145, 36);
            this.ticket_scannen_btn.TabIndex = 6;
            this.ticket_scannen_btn.Text = "Ticket scannen";
            this.ticket_scannen_btn.UseVisualStyleBackColor = true;
            this.ticket_scannen_btn.Click += new System.EventHandler(this.ticket_scannen_btn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.kassenautomat_tickets_cb);
            this.groupBox2.Controls.Add(this.kassenautomat_ticket_bezahlen_btn);
            this.groupBox2.Controls.Add(this.kassenautomat_ausgabe_tb);
            this.groupBox2.Location = new System.Drawing.Point(419, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(381, 547);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kassenautomat";
            // 
            // kassenautomat_tickets_cb
            // 
            this.kassenautomat_tickets_cb.FormattingEnabled = true;
            this.kassenautomat_tickets_cb.Location = new System.Drawing.Point(125, 263);
            this.kassenautomat_tickets_cb.Name = "kassenautomat_tickets_cb";
            this.kassenautomat_tickets_cb.Size = new System.Drawing.Size(145, 21);
            this.kassenautomat_tickets_cb.TabIndex = 5;
            // 
            // kassenautomat_ticket_bezahlen_btn
            // 
            this.kassenautomat_ticket_bezahlen_btn.Location = new System.Drawing.Point(125, 300);
            this.kassenautomat_ticket_bezahlen_btn.Name = "kassenautomat_ticket_bezahlen_btn";
            this.kassenautomat_ticket_bezahlen_btn.Size = new System.Drawing.Size(145, 36);
            this.kassenautomat_ticket_bezahlen_btn.TabIndex = 4;
            this.kassenautomat_ticket_bezahlen_btn.Text = "Ticket bezahlen";
            this.kassenautomat_ticket_bezahlen_btn.UseVisualStyleBackColor = true;
            this.kassenautomat_ticket_bezahlen_btn.Click += new System.EventHandler(this.kassenautomat_ticket_bezahlen_btn_Click);
            // 
            // kassenautomat_ausgabe_tb
            // 
            this.kassenautomat_ausgabe_tb.Location = new System.Drawing.Point(80, 79);
            this.kassenautomat_ausgabe_tb.Multiline = true;
            this.kassenautomat_ausgabe_tb.Name = "kassenautomat_ausgabe_tb";
            this.kassenautomat_ausgabe_tb.ReadOnly = true;
            this.kassenautomat_ausgabe_tb.Size = new System.Drawing.Size(230, 102);
            this.kassenautomat_ausgabe_tb.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.einfahrt_code_tb);
            this.groupBox1.Controls.Add(this.einfahrt_code_eingeben_btn);
            this.groupBox1.Controls.Add(this.einfahrt_ticket_ziehen_btn);
            this.groupBox1.Controls.Add(this.einfahrt_ausgabe_tb);
            this.groupBox1.Location = new System.Drawing.Point(32, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 547);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Einfahrt";
            // 
            // einfahrt_code_tb
            // 
            this.einfahrt_code_tb.Location = new System.Drawing.Point(115, 365);
            this.einfahrt_code_tb.Name = "einfahrt_code_tb";
            this.einfahrt_code_tb.Size = new System.Drawing.Size(145, 20);
            this.einfahrt_code_tb.TabIndex = 3;
            // 
            // einfahrt_code_eingeben_btn
            // 
            this.einfahrt_code_eingeben_btn.Location = new System.Drawing.Point(115, 323);
            this.einfahrt_code_eingeben_btn.Name = "einfahrt_code_eingeben_btn";
            this.einfahrt_code_eingeben_btn.Size = new System.Drawing.Size(145, 36);
            this.einfahrt_code_eingeben_btn.TabIndex = 2;
            this.einfahrt_code_eingeben_btn.Text = "Code eingeben";
            this.einfahrt_code_eingeben_btn.UseVisualStyleBackColor = true;
            this.einfahrt_code_eingeben_btn.Click += new System.EventHandler(this.einfahrt_code_eingeben_btn_Click);
            // 
            // einfahrt_ticket_ziehen_btn
            // 
            this.einfahrt_ticket_ziehen_btn.Location = new System.Drawing.Point(115, 248);
            this.einfahrt_ticket_ziehen_btn.Name = "einfahrt_ticket_ziehen_btn";
            this.einfahrt_ticket_ziehen_btn.Size = new System.Drawing.Size(145, 36);
            this.einfahrt_ticket_ziehen_btn.TabIndex = 1;
            this.einfahrt_ticket_ziehen_btn.Text = "Ticket ziehen";
            this.einfahrt_ticket_ziehen_btn.UseVisualStyleBackColor = true;
            this.einfahrt_ticket_ziehen_btn.Click += new System.EventHandler(this.einfahrt_ticket_ziehen_btn_Click);
            // 
            // einfahrt_ausgabe_tb
            // 
            this.einfahrt_ausgabe_tb.Location = new System.Drawing.Point(77, 79);
            this.einfahrt_ausgabe_tb.Multiline = true;
            this.einfahrt_ausgabe_tb.Name = "einfahrt_ausgabe_tb";
            this.einfahrt_ausgabe_tb.ReadOnly = true;
            this.einfahrt_ausgabe_tb.Size = new System.Drawing.Size(230, 102);
            this.einfahrt_ausgabe_tb.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dashboard_flp);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.gesamtauslastung_lbl);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1218, 683);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Dashboard";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dashboard_flp
            // 
            this.dashboard_flp.Location = new System.Drawing.Point(56, 90);
            this.dashboard_flp.Name = "dashboard_flp";
            this.dashboard_flp.Size = new System.Drawing.Size(1089, 531);
            this.dashboard_flp.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(879, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Gesamtauslastung";
            // 
            // gesamtauslastung_lbl
            // 
            this.gesamtauslastung_lbl.AutoSize = true;
            this.gesamtauslastung_lbl.Location = new System.Drawing.Point(979, 42);
            this.gesamtauslastung_lbl.Name = "gesamtauslastung_lbl";
            this.gesamtauslastung_lbl.Size = new System.Drawing.Size(13, 13);
            this.gesamtauslastung_lbl.TabIndex = 0;
            this.gesamtauslastung_lbl.Text = "0";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Controls.Add(this.umsatzstatistik_gb);
            this.tabPage3.Controls.Add(this.tarif_verwalten_gb);
            this.tabPage3.Controls.Add(this.parkhauskonfiguration_gb);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1218, 683);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Administration";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dauermieter_loeschen_cb);
            this.groupBox4.Controls.Add(this.dauermieter_loeschen_btn);
            this.groupBox4.Controls.Add(this.dauermieter_anzeigen_btn);
            this.groupBox4.Controls.Add(this.dauermieter_anzeigen_dgv);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.dauermieter_parkplatz_cb);
            this.groupBox4.Controls.Add(this.dauermieter_vertragsende_dtp);
            this.groupBox4.Controls.Add(this.dauermieter_bezahlt_cb);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.dauermieter_zugangscode_tb);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.dauermieter_vorname_tb);
            this.groupBox4.Controls.Add(this.dauermieter_name_tb);
            this.groupBox4.Controls.Add(this.dauermieter_anlegen_btn);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(542, 40);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(647, 598);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Dauermieter";
            // 
            // dauermieter_loeschen_cb
            // 
            this.dauermieter_loeschen_cb.FormattingEnabled = true;
            this.dauermieter_loeschen_cb.Location = new System.Drawing.Point(31, 544);
            this.dauermieter_loeschen_cb.Name = "dauermieter_loeschen_cb";
            this.dauermieter_loeschen_cb.Size = new System.Drawing.Size(232, 21);
            this.dauermieter_loeschen_cb.TabIndex = 17;
            // 
            // dauermieter_loeschen_btn
            // 
            this.dauermieter_loeschen_btn.Location = new System.Drawing.Point(289, 544);
            this.dauermieter_loeschen_btn.Name = "dauermieter_loeschen_btn";
            this.dauermieter_loeschen_btn.Size = new System.Drawing.Size(132, 23);
            this.dauermieter_loeschen_btn.TabIndex = 16;
            this.dauermieter_loeschen_btn.Text = "Dauermieter löschen";
            this.dauermieter_loeschen_btn.UseVisualStyleBackColor = true;
            this.dauermieter_loeschen_btn.Click += new System.EventHandler(this.dauermieter_loeschen_btn_Click);
            // 
            // dauermieter_anzeigen_btn
            // 
            this.dauermieter_anzeigen_btn.Location = new System.Drawing.Point(289, 495);
            this.dauermieter_anzeigen_btn.Name = "dauermieter_anzeigen_btn";
            this.dauermieter_anzeigen_btn.Size = new System.Drawing.Size(132, 23);
            this.dauermieter_anzeigen_btn.TabIndex = 15;
            this.dauermieter_anzeigen_btn.Text = "Dauermieter anzeigen";
            this.dauermieter_anzeigen_btn.UseVisualStyleBackColor = true;
            this.dauermieter_anzeigen_btn.Click += new System.EventHandler(this.dauermieter_anzeigen_btn_Click);
            // 
            // dauermieter_anzeigen_dgv
            // 
            this.dauermieter_anzeigen_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dauermieter_anzeigen_dgv.Location = new System.Drawing.Point(31, 329);
            this.dauermieter_anzeigen_dgv.Name = "dauermieter_anzeigen_dgv";
            this.dauermieter_anzeigen_dgv.ReadOnly = true;
            this.dauermieter_anzeigen_dgv.Size = new System.Drawing.Size(580, 150);
            this.dauermieter_anzeigen_dgv.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(28, 254);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "Parkplatz zuweisen";
            // 
            // dauermieter_parkplatz_cb
            // 
            this.dauermieter_parkplatz_cb.FormattingEnabled = true;
            this.dauermieter_parkplatz_cb.Location = new System.Drawing.Point(217, 251);
            this.dauermieter_parkplatz_cb.Name = "dauermieter_parkplatz_cb";
            this.dauermieter_parkplatz_cb.Size = new System.Drawing.Size(204, 21);
            this.dauermieter_parkplatz_cb.TabIndex = 12;
            // 
            // dauermieter_vertragsende_dtp
            // 
            this.dauermieter_vertragsende_dtp.Location = new System.Drawing.Point(217, 203);
            this.dauermieter_vertragsende_dtp.Name = "dauermieter_vertragsende_dtp";
            this.dauermieter_vertragsende_dtp.Size = new System.Drawing.Size(204, 20);
            this.dauermieter_vertragsende_dtp.TabIndex = 11;
            // 
            // dauermieter_bezahlt_cb
            // 
            this.dauermieter_bezahlt_cb.AutoSize = true;
            this.dauermieter_bezahlt_cb.Location = new System.Drawing.Point(340, 163);
            this.dauermieter_bezahlt_cb.Name = "dauermieter_bezahlt_cb";
            this.dauermieter_bezahlt_cb.Size = new System.Drawing.Size(89, 17);
            this.dauermieter_bezahlt_cb.TabIndex = 10;
            this.dauermieter_bezahlt_cb.Text = "Miete bezahlt";
            this.dauermieter_bezahlt_cb.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 209);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Vertragsende";
            // 
            // dauermieter_zugangscode_tb
            // 
            this.dauermieter_zugangscode_tb.Location = new System.Drawing.Point(217, 121);
            this.dauermieter_zugangscode_tb.Name = "dauermieter_zugangscode_tb";
            this.dauermieter_zugangscode_tb.Size = new System.Drawing.Size(204, 20);
            this.dauermieter_zugangscode_tb.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 121);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Zugangscode";
            // 
            // dauermieter_vorname_tb
            // 
            this.dauermieter_vorname_tb.Location = new System.Drawing.Point(217, 84);
            this.dauermieter_vorname_tb.Name = "dauermieter_vorname_tb";
            this.dauermieter_vorname_tb.Size = new System.Drawing.Size(204, 20);
            this.dauermieter_vorname_tb.TabIndex = 6;
            // 
            // dauermieter_name_tb
            // 
            this.dauermieter_name_tb.Location = new System.Drawing.Point(217, 45);
            this.dauermieter_name_tb.Name = "dauermieter_name_tb";
            this.dauermieter_name_tb.Size = new System.Drawing.Size(204, 20);
            this.dauermieter_name_tb.TabIndex = 5;
            // 
            // dauermieter_anlegen_btn
            // 
            this.dauermieter_anlegen_btn.Location = new System.Drawing.Point(289, 290);
            this.dauermieter_anlegen_btn.Name = "dauermieter_anlegen_btn";
            this.dauermieter_anlegen_btn.Size = new System.Drawing.Size(132, 23);
            this.dauermieter_anlegen_btn.TabIndex = 4;
            this.dauermieter_anlegen_btn.Text = "Dauermieter anlegen";
            this.dauermieter_anlegen_btn.UseVisualStyleBackColor = true;
            this.dauermieter_anlegen_btn.Click += new System.EventHandler(this.dauermieter_anlegen_btn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Vorname";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Name";
            // 
            // umsatzstatistik_gb
            // 
            this.umsatzstatistik_gb.Controls.Add(this.report_generieren_btn);
            this.umsatzstatistik_gb.Controls.Add(this.umsatz_monat_jahr_cb);
            this.umsatzstatistik_gb.Controls.Add(this.label5);
            this.umsatzstatistik_gb.Location = new System.Drawing.Point(38, 497);
            this.umsatzstatistik_gb.Name = "umsatzstatistik_gb";
            this.umsatzstatistik_gb.Size = new System.Drawing.Size(467, 141);
            this.umsatzstatistik_gb.TabIndex = 2;
            this.umsatzstatistik_gb.TabStop = false;
            this.umsatzstatistik_gb.Text = "Umsatzstatistik";
            // 
            // report_generieren_btn
            // 
            this.report_generieren_btn.Location = new System.Drawing.Point(324, 100);
            this.report_generieren_btn.Name = "report_generieren_btn";
            this.report_generieren_btn.Size = new System.Drawing.Size(121, 23);
            this.report_generieren_btn.TabIndex = 6;
            this.report_generieren_btn.Text = "Report generieren";
            this.report_generieren_btn.UseVisualStyleBackColor = true;
            this.report_generieren_btn.Click += new System.EventHandler(this.report_generieren_btn_Click);
            // 
            // umsatz_monat_jahr_cb
            // 
            this.umsatz_monat_jahr_cb.FormattingEnabled = true;
            this.umsatz_monat_jahr_cb.Location = new System.Drawing.Point(236, 44);
            this.umsatz_monat_jahr_cb.Name = "umsatz_monat_jahr_cb";
            this.umsatz_monat_jahr_cb.Size = new System.Drawing.Size(148, 21);
            this.umsatz_monat_jahr_cb.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Monat/Jahr";
            // 
            // tarif_verwalten_gb
            // 
            this.tarif_verwalten_gb.Controls.Add(this.feiertag_aktiv_cb);
            this.tarif_verwalten_gb.Controls.Add(this.label14);
            this.tarif_verwalten_gb.Controls.Add(this.tarif_wochenende_nud);
            this.tarif_verwalten_gb.Controls.Add(this.label13);
            this.tarif_verwalten_gb.Controls.Add(this.nachttarif_preis_15_min_nud);
            this.tarif_verwalten_gb.Controls.Add(this.label12);
            this.tarif_verwalten_gb.Controls.Add(this.tarif_verwalten_speichern_btn);
            this.tarif_verwalten_gb.Controls.Add(this.tagespauschale_preis_nud);
            this.tarif_verwalten_gb.Controls.Add(this.tarif_preis_15_min_nud);
            this.tarif_verwalten_gb.Controls.Add(this.label4);
            this.tarif_verwalten_gb.Controls.Add(this.label3);
            this.tarif_verwalten_gb.Location = new System.Drawing.Point(38, 243);
            this.tarif_verwalten_gb.Name = "tarif_verwalten_gb";
            this.tarif_verwalten_gb.Size = new System.Drawing.Size(467, 238);
            this.tarif_verwalten_gb.TabIndex = 1;
            this.tarif_verwalten_gb.TabStop = false;
            this.tarif_verwalten_gb.Text = "Tarif verwalten";
            // 
            // tarif_verwalten_speichern_btn
            // 
            this.tarif_verwalten_speichern_btn.Location = new System.Drawing.Point(346, 195);
            this.tarif_verwalten_speichern_btn.Name = "tarif_verwalten_speichern_btn";
            this.tarif_verwalten_speichern_btn.Size = new System.Drawing.Size(75, 23);
            this.tarif_verwalten_speichern_btn.TabIndex = 5;
            this.tarif_verwalten_speichern_btn.Text = "Speichern";
            this.tarif_verwalten_speichern_btn.UseVisualStyleBackColor = true;
            // 
            // tagespauschale_preis_nud
            // 
            this.tagespauschale_preis_nud.DecimalPlaces = 2;
            this.tagespauschale_preis_nud.Location = new System.Drawing.Point(236, 151);
            this.tagespauschale_preis_nud.Name = "tagespauschale_preis_nud";
            this.tagespauschale_preis_nud.Size = new System.Drawing.Size(120, 20);
            this.tagespauschale_preis_nud.TabIndex = 5;
            // 
            // tarif_preis_15_min_nud
            // 
            this.tarif_preis_15_min_nud.DecimalPlaces = 2;
            this.tarif_preis_15_min_nud.Location = new System.Drawing.Point(236, 44);
            this.tarif_preis_15_min_nud.Name = "tarif_preis_15_min_nud";
            this.tarif_preis_15_min_nud.Size = new System.Drawing.Size(120, 20);
            this.tarif_preis_15_min_nud.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tagespauschale";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tagestarif (Preis pro 15min)";
            // 
            // parkhauskonfiguration_gb
            // 
            this.parkhauskonfiguration_gb.Controls.Add(this.parkhauskonfiguration_speichern_btn);
            this.parkhauskonfiguration_gb.Controls.Add(this.parkhauskonfiguration_plaetze_nud);
            this.parkhauskonfiguration_gb.Controls.Add(this.parkhauskonfiguration_stockwerke_nud);
            this.parkhauskonfiguration_gb.Controls.Add(this.label2);
            this.parkhauskonfiguration_gb.Controls.Add(this.label1);
            this.parkhauskonfiguration_gb.Location = new System.Drawing.Point(38, 40);
            this.parkhauskonfiguration_gb.Name = "parkhauskonfiguration_gb";
            this.parkhauskonfiguration_gb.Size = new System.Drawing.Size(467, 185);
            this.parkhauskonfiguration_gb.TabIndex = 0;
            this.parkhauskonfiguration_gb.TabStop = false;
            this.parkhauskonfiguration_gb.Text = "Parkhauskonfiguration";
            // 
            // parkhauskonfiguration_speichern_btn
            // 
            this.parkhauskonfiguration_speichern_btn.Location = new System.Drawing.Point(346, 143);
            this.parkhauskonfiguration_speichern_btn.Name = "parkhauskonfiguration_speichern_btn";
            this.parkhauskonfiguration_speichern_btn.Size = new System.Drawing.Size(75, 23);
            this.parkhauskonfiguration_speichern_btn.TabIndex = 4;
            this.parkhauskonfiguration_speichern_btn.Text = "Speichern";
            this.parkhauskonfiguration_speichern_btn.UseVisualStyleBackColor = true;
            this.parkhauskonfiguration_speichern_btn.Click += new System.EventHandler(this.parkhauskonfiguration_speichern_btn_Click);
            // 
            // parkhauskonfiguration_plaetze_nud
            // 
            this.parkhauskonfiguration_plaetze_nud.Location = new System.Drawing.Point(236, 82);
            this.parkhauskonfiguration_plaetze_nud.Name = "parkhauskonfiguration_plaetze_nud";
            this.parkhauskonfiguration_plaetze_nud.Size = new System.Drawing.Size(120, 20);
            this.parkhauskonfiguration_plaetze_nud.TabIndex = 3;
            // 
            // parkhauskonfiguration_stockwerke_nud
            // 
            this.parkhauskonfiguration_stockwerke_nud.Location = new System.Drawing.Point(236, 45);
            this.parkhauskonfiguration_stockwerke_nud.Name = "parkhauskonfiguration_stockwerke_nud";
            this.parkhauskonfiguration_stockwerke_nud.Size = new System.Drawing.Size(120, 20);
            this.parkhauskonfiguration_stockwerke_nud.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Plätze pro Stockwerke";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stockwerke";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(28, 83);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(134, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Nachttarif (Preis pro 15min)";
            // 
            // nachttarif_preis_15_min_nud
            // 
            this.nachttarif_preis_15_min_nud.DecimalPlaces = 2;
            this.nachttarif_preis_15_min_nud.Location = new System.Drawing.Point(236, 81);
            this.nachttarif_preis_15_min_nud.Name = "nachttarif_preis_15_min_nud";
            this.nachttarif_preis_15_min_nud.Size = new System.Drawing.Size(120, 20);
            this.nachttarif_preis_15_min_nud.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(28, 117);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "Wochenendtarif";
            // 
            // tarif_wochenende_nud
            // 
            this.tarif_wochenende_nud.DecimalPlaces = 2;
            this.tarif_wochenende_nud.Location = new System.Drawing.Point(236, 115);
            this.tarif_wochenende_nud.Name = "tarif_wochenende_nud";
            this.tarif_wochenende_nud.Size = new System.Drawing.Size(120, 20);
            this.tarif_wochenende_nud.TabIndex = 9;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(29, 183);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(0, 13);
            this.label14.TabIndex = 10;
            // 
            // feiertag_aktiv_cb
            // 
            this.feiertag_aktiv_cb.AutoSize = true;
            this.feiertag_aktiv_cb.Location = new System.Drawing.Point(32, 195);
            this.feiertag_aktiv_cb.Name = "feiertag_aktiv_cb";
            this.feiertag_aktiv_cb.Size = new System.Drawing.Size(126, 17);
            this.feiertag_aktiv_cb.TabIndex = 11;
            this.feiertag_aktiv_cb.Text = "Heute ist ein Feiertag";
            this.feiertag_aktiv_cb.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 749);
            this.Controls.Add(this.Dashboard);
            this.Name = "Form1";
            this.Text = "ParkhausSW";
            this.Dashboard.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dauermieter_anzeigen_dgv)).EndInit();
            this.umsatzstatistik_gb.ResumeLayout(false);
            this.umsatzstatistik_gb.PerformLayout();
            this.tarif_verwalten_gb.ResumeLayout(false);
            this.tarif_verwalten_gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tagespauschale_preis_nud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarif_preis_15_min_nud)).EndInit();
            this.parkhauskonfiguration_gb.ResumeLayout(false);
            this.parkhauskonfiguration_gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parkhauskonfiguration_plaetze_nud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parkhauskonfiguration_stockwerke_nud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nachttarif_preis_15_min_nud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarif_wochenende_nud)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Dashboard;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox ausfahrt_ausgabe_tb;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox kassenautomat_ausgabe_tb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button einfahrt_ticket_ziehen_btn;
        private System.Windows.Forms.TextBox einfahrt_ausgabe_tb;
        private System.Windows.Forms.ComboBox ausfahrt_tickets_cb;
        private System.Windows.Forms.Button ticket_scannen_btn;
        private System.Windows.Forms.ComboBox kassenautomat_tickets_cb;
        private System.Windows.Forms.Button kassenautomat_ticket_bezahlen_btn;
        private System.Windows.Forms.TextBox einfahrt_code_tb;
        private System.Windows.Forms.Button einfahrt_code_eingeben_btn;
        private System.Windows.Forms.TextBox ausfahrt_code_tb;
        private System.Windows.Forms.Button ausfahrt_code_eingeben_btn;
        private System.Windows.Forms.GroupBox umsatzstatistik_gb;
        private System.Windows.Forms.GroupBox tarif_verwalten_gb;
        private System.Windows.Forms.GroupBox parkhauskonfiguration_gb;
        private System.Windows.Forms.ComboBox umsatz_monat_jahr_cb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown tagespauschale_preis_nud;
        private System.Windows.Forms.NumericUpDown tarif_preis_15_min_nud;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown parkhauskonfiguration_plaetze_nud;
        private System.Windows.Forms.NumericUpDown parkhauskonfiguration_stockwerke_nud;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button report_generieren_btn;
        private System.Windows.Forms.Button tarif_verwalten_speichern_btn;
        private System.Windows.Forms.Button parkhauskonfiguration_speichern_btn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label gesamtauslastung_lbl;
        private System.Windows.Forms.FlowLayoutPanel dashboard_flp;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button dauermieter_anlegen_btn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox dauermieter_vorname_tb;
        private System.Windows.Forms.TextBox dauermieter_name_tb;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox dauermieter_parkplatz_cb;
        private System.Windows.Forms.DateTimePicker dauermieter_vertragsende_dtp;
        private System.Windows.Forms.CheckBox dauermieter_bezahlt_cb;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox dauermieter_zugangscode_tb;
        private System.Windows.Forms.Button dauermieter_anzeigen_btn;
        private System.Windows.Forms.DataGridView dauermieter_anzeigen_dgv;
        private System.Windows.Forms.ComboBox dauermieter_loeschen_cb;
        private System.Windows.Forms.Button dauermieter_loeschen_btn;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox feiertag_aktiv_cb;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown tarif_wochenende_nud;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown nachttarif_preis_15_min_nud;
    }
}

