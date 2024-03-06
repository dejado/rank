namespace rank
{
    partial class Rank
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbRank = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btfinish = new System.Windows.Forms.Button();
            this.btAgain = new System.Windows.Forms.Button();
            this.ranking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name_lb = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbRank
            // 
            this.lbRank.AutoSize = true;
            this.lbRank.Cursor = System.Windows.Forms.Cursors.No;
            this.lbRank.Font = new System.Drawing.Font("휴먼엑스포", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbRank.Location = new System.Drawing.Point(528, 25);
            this.lbRank.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbRank.Name = "lbRank";
            this.lbRank.Size = new System.Drawing.Size(94, 41);
            this.lbRank.TabIndex = 2;
            this.lbRank.Text = "순위";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ranking,
            this.name,
            this.score,
            this.date});
            this.dataGridView1.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dataGridView1.Location = new System.Drawing.Point(243, 102);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(654, 543);
            this.dataGridView1.TabIndex = 4;
            // 
            // btfinish
            // 
            this.btfinish.Font = new System.Drawing.Font("휴먼엑스포", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btfinish.Location = new System.Drawing.Point(950, 191);
            this.btfinish.Margin = new System.Windows.Forms.Padding(2);
            this.btfinish.Name = "btfinish";
            this.btfinish.Size = new System.Drawing.Size(81, 32);
            this.btfinish.TabIndex = 5;
            this.btfinish.Text = "종료";
            this.btfinish.UseVisualStyleBackColor = true;
            this.btfinish.Click += new System.EventHandler(this.btfinish_Click);
            // 
            // btAgain
            // 
            this.btAgain.Font = new System.Drawing.Font("휴먼엑스포", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btAgain.Location = new System.Drawing.Point(939, 144);
            this.btAgain.Margin = new System.Windows.Forms.Padding(2);
            this.btAgain.Name = "btAgain";
            this.btAgain.Size = new System.Drawing.Size(103, 32);
            this.btAgain.TabIndex = 6;
            this.btAgain.Text = "다시하기";
            this.btAgain.UseVisualStyleBackColor = true;
            this.btAgain.Click += new System.EventHandler(this.btAgain_Click);
            // 
            // ranking
            // 
            this.ranking.HeaderText = "ranking";
            this.ranking.MinimumWidth = 8;
            this.ranking.Name = "ranking";
            this.ranking.Width = 60;
            // 
            // name
            // 
            this.name.HeaderText = "name";
            this.name.MinimumWidth = 8;
            this.name.Name = "name";
            this.name.Width = 150;
            // 
            // score
            // 
            this.score.HeaderText = "score";
            this.score.MinimumWidth = 8;
            this.score.Name = "score";
            // 
            // date
            // 
            this.date.HeaderText = "date";
            this.date.MinimumWidth = 8;
            this.date.Name = "date";
            this.date.Width = 150;
            // 
            // name_lb
            // 
            this.name_lb.AutoSize = true;
            this.name_lb.Font = new System.Drawing.Font("휴먼엑스포", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.name_lb.Location = new System.Drawing.Point(35, 27);
            this.name_lb.Name = "name_lb";
            this.name_lb.Size = new System.Drawing.Size(58, 26);
            this.name_lb.TabIndex = 7;
            this.name_lb.Text = "이름";
            // 
            // Rank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::rank.Properties.Resources.main;
            this.ClientSize = new System.Drawing.Size(1061, 670);
            this.Controls.Add(this.name_lb);
            this.Controls.Add(this.btAgain);
            this.Controls.Add(this.btfinish);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lbRank);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Rank";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbRank;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btfinish;
        private System.Windows.Forms.Button btAgain;
        private System.Windows.Forms.DataGridViewTextBoxColumn ranking;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn score;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.Label name_lb;
    }
}

