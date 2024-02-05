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
            this.ranking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btfinish = new System.Windows.Forms.Button();
            this.btAgain = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbRank
            // 
            this.lbRank.AutoSize = true;
            this.lbRank.Cursor = System.Windows.Forms.Cursors.No;
            this.lbRank.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbRank.Location = new System.Drawing.Point(406, 33);
            this.lbRank.Name = "lbRank";
            this.lbRank.Size = new System.Drawing.Size(124, 28);
            this.lbRank.TabIndex = 2;
            this.lbRank.Text = "Ranking";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ranking,
            this.name,
            this.score,
            this.date});
            this.dataGridView1.Location = new System.Drawing.Point(30, 97);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(938, 348);
            this.dataGridView1.TabIndex = 4;
            // 
            // ranking
            // 
            this.ranking.HeaderText = "ranking";
            this.ranking.MinimumWidth = 8;
            this.ranking.Name = "ranking";
            this.ranking.Width = 150;
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
            this.score.Width = 150;
            // 
            // date
            // 
            this.date.HeaderText = "date";
            this.date.MinimumWidth = 8;
            this.date.Name = "date";
            this.date.Width = 150;
            // 
            // btfinish
            // 
            this.btfinish.Location = new System.Drawing.Point(246, 463);
            this.btfinish.Name = "btfinish";
            this.btfinish.Size = new System.Drawing.Size(75, 38);
            this.btfinish.TabIndex = 5;
            this.btfinish.Text = "종료";
            this.btfinish.UseVisualStyleBackColor = true;
            this.btfinish.Click += new System.EventHandler(this.btfinish_Click);
            // 
            // btAgain
            // 
            this.btAgain.Location = new System.Drawing.Point(65, 463);
            this.btAgain.Name = "btAgain";
            this.btAgain.Size = new System.Drawing.Size(103, 38);
            this.btAgain.TabIndex = 6;
            this.btAgain.Text = "다시하기";
            this.btAgain.UseVisualStyleBackColor = true;
            this.btAgain.Click += new System.EventHandler(this.btAgain_Click);
            // 
            // Rank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 522);
            this.Controls.Add(this.btAgain);
            this.Controls.Add(this.btfinish);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lbRank);
            this.Name = "Rank";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbRank;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ranking;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn score;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.Button btfinish;
        private System.Windows.Forms.Button btAgain;
    }
}

