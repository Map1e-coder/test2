using System.Drawing;

namespace ChordProgressionApp;

internal sealed class MainForm : Form
{
    private readonly ChordProgressionGenerator _generator = new();
    private readonly Label[] _chordLabels = new Label[4];

    public MainForm()
    {
        Text = "コード進行ジェネレーター";
        ClientSize = new Size(680, 280);
        MinimumSize = new Size(600, 280);
        StartPosition = FormStartPosition.CenterScreen;
        Font = new Font("Yu Gothic UI", 10F);
        BackColor = Color.FromArgb(246, 247, 249);

        var titleLabel = new Label
        {
            AutoSize = true,
            Text = "Cメジャーのコード進行",
            Font = new Font(Font.FontFamily, 18F, FontStyle.Bold),
            ForeColor = Color.FromArgb(35, 39, 47),
            Anchor = AnchorStyles.None
        };

        var chordPanel = new TableLayoutPanel
        {
            ColumnCount = 4,
            RowCount = 1,
            Dock = DockStyle.Fill,
            Padding = new Padding(12, 0, 12, 0)
        };

        for (var index = 0; index < _chordLabels.Length; index++)
        {
            chordPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));

            var chordLabel = new Label
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(8),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(Font.FontFamily, 20F, FontStyle.Bold),
                ForeColor = Color.FromArgb(46, 94, 170),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            _chordLabels[index] = chordLabel;
            chordPanel.Controls.Add(chordLabel, index, 0);
        }

        var redrawButton = new Button
        {
            AutoSize = true,
            Text = "再抽選",
            Font = new Font(Font.FontFamily, 11F, FontStyle.Bold),
            Padding = new Padding(24, 7, 24, 7),
            Anchor = AnchorStyles.None,
            BackColor = Color.FromArgb(46, 94, 170),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand
        };
        redrawButton.FlatAppearance.BorderSize = 0;
        redrawButton.Click += (_, _) => DrawProgression();

        var layout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 3,
            Padding = new Padding(24, 18, 24, 22)
        };
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
        layout.Controls.Add(titleLabel, 0, 0);
        layout.Controls.Add(chordPanel, 0, 1);
        layout.Controls.Add(redrawButton, 0, 2);

        Controls.Add(layout);
        AcceptButton = redrawButton;

        DrawProgression();
    }

    private void DrawProgression()
    {
        var progression = _generator.Generate();

        for (var index = 0; index < _chordLabels.Length; index++)
        {
            _chordLabels[index].Text = progression[index];
        }
    }
}
