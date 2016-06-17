using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordPadSharp
{
	public partial class FormScreenShot : Form
	{
		private bool IsClick = false;				// 클릭 상태
		private Point Start = new Point();			// 클릭 시작 좌표
		private Point End = new Point();			// 클릭 끝 좌표
		private Point Img_Start = new Point();		// 그림 시작 좌표

		private Rectangle Rect;
		int Rect_Width;
		int Rect_Height;

		public FormScreenShot()
		{
			InitializeComponent();

			DoubleBuffered = true;

			CreateBackImage();
		}

		/* 사각형의 시작 좌표를 받아옴 */
		private void FormScreenshot_MouseDown(object sender, MouseEventArgs e)
		{
			IsClick = true;
			Start.X = e.X;
			Start.Y = e.Y;
		}

		/* 선택된 영역을 클립보드에 복사 */
		private void FormScreenshot_MouseUp(object sender, MouseEventArgs e)
		{
			IsClick = false;
			Close();

			if ((Rect_Height == 0) || (Rect_Width == 0))
			{
				MessageBox.Show("캡쳐된 영역이 없습니다!");
				Clipboard.Clear();
			}
			else
			{
				Point point = new Point();
				point = PointToScreen(Img_Start);

				Rectangle select_rect = new Rectangle(point.X, point.Y, Rect_Width, Rect_Height);
				Bitmap select_screen = new Bitmap(select_rect.Width, select_rect.Height, PixelFormat.Format32bppArgb);

				Graphics g = Graphics.FromImage(select_screen);
				g.CopyFromScreen(select_rect.X, select_rect.Y, 0, 0, select_rect.Size, CopyPixelOperation.SourceCopy);

				Clipboard.Clear();
				Clipboard.SetImage(select_screen);
			}
		}

		/* 사각형 그림 */
		private void FormScreenshot_MouseMove(object sender, MouseEventArgs e)
		{
			if (IsClick)
			{
				Img_Start.X = Math.Min(Start.X, e.X);
				Img_Start.Y = Math.Min(Start.Y, e.Y);

				Rect_Width = Math.Max(Start.X, e.X) - Math.Min(Start.X, e.X);
				Rect_Height = Math.Max(Start.Y, e.Y) - Math.Min(Start.Y, e.Y);

				Rect = new Rectangle(Img_Start.X, Img_Start.Y, Rect_Width, Rect_Height);

				Refresh();
			}
		}

		/* paint 이벤트 발생 시 작동 */
		protected override void OnPaint(PaintEventArgs e)
		{
			using (Pen pen = new Pen(Color.Red, 1))
				e.Graphics.DrawRectangle(pen, Rect);
		}

		/* 캡쳐될 스크린 생성 */
		private void CreateBackImage()
		{
			Rectangle screen_rect = Screen.PrimaryScreen.Bounds;
			Bitmap full_screen = new Bitmap(screen_rect.Width, screen_rect.Width, PixelFormat.Format32bppArgb);

			Graphics g = Graphics.FromImage(full_screen);
			g.CopyFromScreen(screen_rect.X, screen_rect.Y, 0, 0, screen_rect.Size, CopyPixelOperation.SourceCopy);

			Cursor = Cursors.Cross;
			BackgroundImage = full_screen;
			Location = new Point(0, 0);
			Size = full_screen.Size;
		}
	}
}