using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordPadSharp
{
	public partial class FormMain : Form
	{
		private String FilePath = null;     // 현재 파일의 경로
		private String FileName = null;     // 현재 파일의 이름
		private String FileType = null;     // 현재 파일의 형식

		private bool IsTextChanged = false;

		private int DefaultCharOffset = -11;
		private int DefaultWidth = 0;
		private int DefaultHeight = 0;

		private int Margin_Top = 0;
		private int Margin_Bottom = 0;
		private int Margin_Left = 0;
		private int Margin_Right = 0;

		private bool Mouse_Click = false;

		private int PageType = 0;

		public FormMain()
		{
			InitializeComponent();
			MyInit();
			AutoResizePanel();
		}

		private void FormMain_SizeChanged(object sender, EventArgs e)
		{
			AutoResizePanel();
		}

		private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			// RichTextBox의 내용이 변경된 경우
			if (IsTextChanged == true)
			{
				// 확인창 띄우기
				FormDialog formDialog = new FormDialog();
				formDialog.Owner = this;

				DialogResult result = formDialog.ShowDialog();

				switch (result)
				{
					case DialogResult.Yes:
						menuStrip_File_Save_Click(null, null);
						break;

					case DialogResult.No:
						break;

					case DialogResult.Cancel:
						e.Cancel = true;
						break;

					default:
						break;
				}
			}
		}

		/* 파일 > 새로 만들기 */
		private void menuStrip_File_Create_Click(object sender, EventArgs e)
		{
			// RichTextBox의 내용이 변경된 경우 
			if (IsTextChanged == true)
			{
				// 확인창 띄우기
				FormDialog formDialog = new FormDialog();
				formDialog.Owner = this;

				DialogResult result = formDialog.ShowDialog();

				switch (result)
				{
					case DialogResult.Yes:
						menuStrip_File_Save_Click(null, null);
						break;

					case DialogResult.No:
						break;

					case DialogResult.Cancel:
						break;

					default:
						break;
				}
			}

			Controls.Clear();
			InitializeComponent();
			MyInit();
			AutoResizePanel();
		}

		/* 파일 > 열기 */
		private void menuStrip_File_Open_Click(object sender, EventArgs e)
		{
			try
			{
				if (openFileDialog_File.ShowDialog() == DialogResult.OK)
				{
					// 여는 파일의 형식이 "*.rtf"인 경우, RichText로 저장
					// 그 외의 경우, PlainText로 저장
					if (Path.GetExtension(openFileDialog_File.FileName) == ".rtf")
						richTextBox.LoadFile(openFileDialog_File.FileName, RichTextBoxStreamType.RichText);
					else
						richTextBox.LoadFile(openFileDialog_File.FileName, RichTextBoxStreamType.PlainText);

					// 현재 파일 변수 설정
					FilePath = Path.GetFullPath(openFileDialog_File.FileName);
					FileName = Path.GetFileName(openFileDialog_File.FileName);
					FileType = Path.GetExtension(openFileDialog_File.FileName);

					Text = FileName + " - WordPad#";
				}
			}
			catch (Exception)
			{
				MessageBox.Show("파일을 여는 도중에 문제가 발생했습니다!");
			}
		}

		/* 파일 > 저장 */
		private void menuStrip_File_Save_Click(object sender, EventArgs e)
		{
			// 현재 열려있는 파일이 없는 경우, SaveFileDialog 창 띄움
			// 현재 열려있는 파일이 있는 경우, 현재 파일에 저장
			if (openFileDialog_File.FileName == "")
			{
				saveFileDialog.FileName = FileName;

				if (saveFileDialog.ShowDialog() == DialogResult.OK && (saveFileDialog.FileName.Length > 0))
				{
					// 파일의 저장 형식이 "*.rtf"인 경우, RichText로 저장
					// 그 외의 경우, PlainText로 저장
					if (Path.GetExtension(saveFileDialog.FileName) == ".rtf")
						richTextBox.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
					else
						richTextBox.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);

					openFileDialog_File.FileName = saveFileDialog.FileName;

					// 현재 파일 변수 설정
					FilePath = Path.GetFullPath(openFileDialog_File.FileName);
					FileName = Path.GetFileName(openFileDialog_File.FileName);
					FileType = Path.GetExtension(openFileDialog_File.FileName);

					Text = FileName + " - WordPad#";
				}
			}
			else
			{
				// 현재 열려있는 파일의 형식이 "*.rtf"인 경우, RichText로 저장
				// 그 외의 경우, PlainText로 저장
				if (FileType == ".rtf")
					richTextBox.SaveFile(openFileDialog_File.FileName, RichTextBoxStreamType.RichText);
				else
					richTextBox.SaveFile(openFileDialog_File.FileName, RichTextBoxStreamType.PlainText);
			}

			IsTextChanged = false;
		}

		/* 파일 > 다른 이름으로 저장 */
		private void menuStrip_File_SaveAs_Click(object sender, EventArgs e)
		{
			if (saveFileDialog.ShowDialog() == DialogResult.OK && (saveFileDialog.FileName.Length > 0))
			{
				// 파일의 저장 형식이 "*.rtf"인 경우, RichText로 저장
				// 그 외의 경우, PlainText로 저장
				if (Path.GetExtension(saveFileDialog.FileName) == ".rtf")
					richTextBox.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
				else
					richTextBox.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
			}
		}

		/* 파일 > 인쇄 */
		private void menuStrip_File_Print_Click(object sender, EventArgs e)
		{
			MessageBox.Show("아직 개발 중 입니다!");
		}

		/* 파일 > 페이지 설정 */
		private void menuStrip_File_PageSet_Click(object sender, EventArgs e)
		{
			FormPage formPage = new FormPage(PageType, Margin_Left, Margin_Top, Margin_Right, Margin_Bottom);
			formPage.Owner = this;

			formPage.ShowDialog();

			switch (formPage.DialogResult)
			{
				case DialogResult.OK:
					PageType = formPage.MyType;
					Margin_Left = formPage.MyPadding.Left;
					Margin_Right = formPage.MyPadding.Right;
					Margin_Top = formPage.MyPadding.Top;
					Margin_Bottom = formPage.MyPadding.Bottom;
					AutoResizePanel();
					break;
				case DialogResult.Cancel:
					break;
				default:
					break;
			}
		}

		/* 파일 > 전자 메일로 보내기 */
		private void menuStrip_File_Mail_Click(object sender, EventArgs e)
		{
			menuStrip_File_Save_Click(null, null);

			FormMail formMail = new FormMail(FilePath);
			formMail.Owner = this;
			formMail.ShowDialog();
		}

		/* 파일 > WordPad# 정보 */
		private void menuStrip_File_Info_Click(object sender, EventArgs e)
		{
			FormInfo formInfo = new FormInfo();
			formInfo.ShowDialog();
		}

		/* 파일 > 끝내기 */
		private void menuStrip_File_Exit_Click(object sender, EventArgs e)
		{
			Close();
		}

		/* 편집 > 실행 취소 */
		private void menuStrip_Edit_Undo_Click(object sender, EventArgs e)
		{
			richTextBox.Undo();
		}

		/* 편집 > 다시 실행 */
		private void menuStrip_Edit_Redo_Click(object sender, EventArgs e)
		{
			richTextBox.Redo();
		}

		/* 편집 > 잘라내기 */
		private void menuStrip_Edit_Cut_Click(object sender, EventArgs e)
		{
			richTextBox.Cut();
		}

		/* 편집 > 복사 */
		private void menuStrip_Edit_Copy_Click(object sender, EventArgs e)
		{
			richTextBox.Copy();
		}

		/* 편집 > 붙여넣기 */
		private void menuStrip_Edit_Paste_Click(object sender, EventArgs e)
		{
			// 현재 작업 중인 파일의 형식이 "rtf"인 경우, 형식을 유지하여 붙여넣음
			// 그 외의 경우, 텍스트 형식으로 붙여넣음
			if (FileType == ".rtf")
				richTextBox.Paste();
			else
				richTextBox.AppendText(Clipboard.GetText());
		}

		/* 편집 > 찾기 */
		private void menuStrip_Edit_Find_Click(object sender, EventArgs e)
		{
			FormSearch formSearch = new FormSearch();
			formSearch.Owner = this;

			formSearch.ShowDialog();
		}

		/* 편집 > 바꾸기 */
		private void menuStrip_Edit_Replace_Click(object sender, EventArgs e)
		{
			FormReplace formReplace = new FormReplace();
			formReplace.Owner = this;

			formReplace.ShowDialog();
		}

		/* 편집 > 모두 선택 */
		private void menuStrip_Edit_SelectAll_Click(object sender, EventArgs e)
		{
			richTextBox.SelectAll();
		}

		/* 편집 > 시간/날짜 */
		private void menuStrip_Edit_Date_Click(object sender, EventArgs e)
		{
			FormDate formDate = new FormDate();
			formDate.Owner = this;

			formDate.ShowDialog();

			switch (formDate.DialogResult)
			{
				case DialogResult.OK:
					richTextBox.AppendText(formDate.DateString);
					break;

				case DialogResult.Cancel:
					break;

				default:
					break;
			}
		}

		/* 서식 > 글꼴 */
		private void menuStrip_Form_Font_Click(object sender, EventArgs e)
		{
			if (fontDialog.ShowDialog() == DialogResult.OK)
			{
				richTextBox.SelectionFont = fontDialog.Font;

				AutoReflectFont();
			}
		}

		/* 서식 > 아래 첨자 */
		private void menuStrip_Form_Down_Click(object sender, EventArgs e)
		{
			// 버튼이 체크 상태일 때, 아래 첨자 실행
			// 버튼이 해제 상태일 때, 아래 첨자 해제
			if (menuStrip_Form_Down.CheckState == CheckState.Checked)
			{
				richTextBox.SelectionCharOffset = DefaultCharOffset;
				richTextBox.SelectionCharOffset -= 3;

				toolStrip_Up_Down.CheckState = CheckState.Checked;

				menuStrip_Form_Up.CheckState = CheckState.Unchecked;
				toolStrip_Up_Up.CheckState = CheckState.Unchecked;
			}
			else if (menuStrip_Form_Down.CheckState == CheckState.Unchecked)
			{
				richTextBox.SelectionCharOffset = DefaultCharOffset;

				toolStrip_Up_Down.CheckState = CheckState.Unchecked;
			}
		}

		/* 서식 > 위 첨자 */
		private void menuStrip_Form_Up_Click(object sender, EventArgs e)
		{
			// 버튼이 체크 상태일 때, 위 첨자 실행
			// 버튼이 해제 상태일 때, 위 첨자 해제
			if (menuStrip_Form_Up.CheckState == CheckState.Checked)
			{
				richTextBox.SelectionCharOffset = DefaultCharOffset;
				richTextBox.SelectionCharOffset += 3;

				toolStrip_Up_Up.CheckState = CheckState.Checked;

				menuStrip_Form_Down.CheckState = CheckState.Unchecked;
				toolStrip_Up_Down.CheckState = CheckState.Unchecked;
			}
			else if (menuStrip_Form_Up.CheckState == CheckState.Unchecked)
			{
				richTextBox.SelectionCharOffset = DefaultCharOffset;

				toolStrip_Up_Up.CheckState = CheckState.Unchecked;
			}
		}

		/* 서식 > 텍스트 강조 색 */
		private void menuStrip_Form_Highlight_Click(object sender, EventArgs e)
		{
			// 버튼이 체크 상태일 때, 텍스트 강조 실행
			// 버튼이 해제 상태일 때, 텍스트 강조 해제
			if (menuStrip_Form_Highlight.CheckState == CheckState.Checked)
			{
				richTextBox.SelectionBackColor = colorDialog_Highlight.Color;

				toolStrip_Up_Highlight.CheckState = CheckState.Checked;
			}
			else if (menuStrip_Form_Highlight.CheckState == CheckState.Unchecked)
			{
				richTextBox.SelectionBackColor = Color.Transparent;

				toolStrip_Up_Highlight.CheckState = CheckState.Unchecked;
			}

			menuStrip_Form.HideDropDown();
		}

		/* 서식 > 텍스트 강조 색 > 색상 변경 */
		private void menuStrip_Form_Highligt_Color_Click(object sender, EventArgs e)
		{
			if (colorDialog_Highlight.ShowDialog() == DialogResult.OK)
			{
				richTextBox.SelectionBackColor = colorDialog_Highlight.Color;

				menuStrip_Form_Highlight.CheckState = CheckState.Checked;
				toolStrip_Up_Highlight.CheckState = CheckState.Checked;
			}
		}

		/* 서식 > 텍스트 색 */
		private void menuStrip_Form_FontColor_Click(object sender, EventArgs e)
		{
			if (colorDialog_Font.ShowDialog() == DialogResult.OK)
				richTextBox.SelectionColor = colorDialog_Font.Color;
		}

		/* 서식 > 내어쓰기 */
		private void menuStrip_Form_IndentDecrease_Click(object sender, EventArgs e)
		{
			richTextBox.SelectionIndent -= 8;
		}

		/* 서식 > 들여쓰기 */
		private void menuStrip_Form_IndentIncrease_Click(object sender, EventArgs e)
		{
			richTextBox.SelectionIndent += 8;
		}

		/* 서식 > 글머리 기호 > Bullet */
		private void menuStrip_Form_List_Bullet_Click(object sender, EventArgs e)
		{
			if (menuStrip_Form_List_Bullet.CheckState == CheckState.Checked)
			{
				menuStrip_Form_IndentIncrease_Click(null, null);
				richTextBox.SelectionBullet = true;

				menuStrip_Form_List.CheckState = CheckState.Checked;
				toolStrip_Down_ListBullet.CheckState = CheckState.Checked;

				menuStrip_Form_List_Number.CheckState = CheckState.Unchecked;
			}
			else if (menuStrip_Form_List_Bullet.CheckState == CheckState.Unchecked)
			{
				menuStrip_Form_IndentDecrease_Click(null, null);
				richTextBox.SelectionBullet = false;

				menuStrip_Form_List.CheckState = CheckState.Unchecked;
				toolStrip_Down_ListBullet.CheckState = CheckState.Unchecked;
			}
		}

		/* 서식 > 글머리 기호 > 번호 매기기 */
		private void menuStrip_Form_List_Number_Click(object sender, EventArgs e)
		{
			if (menuStrip_Form_List_Number.CheckState == CheckState.Checked)
			{
				MessageBox.Show("아직 개발 중 입니다!");

				menuStrip_Form_IndentIncrease_Click(null, null);
				//richTextBox.SelectionBullet = true;

				menuStrip_Form_List.CheckState = CheckState.Checked;
				toolStrip_Down_ListBullet.CheckState = CheckState.Checked;

				menuStrip_Form_List_Number.CheckState = CheckState.Unchecked;
			}
			else if (menuStrip_Form_List_Bullet.CheckState == CheckState.Unchecked)
			{
				MessageBox.Show("아직 개발 중 입니다!");

				menuStrip_Form_IndentDecrease_Click(null, null);
				//richTextBox.SelectionBullet = false;

				menuStrip_Form_List.CheckState = CheckState.Unchecked;
				toolStrip_Down_ListBullet.CheckState = CheckState.Unchecked;

				menuStrip_Form_List_Number.CheckState = CheckState.Unchecked;
			}
		}

		/* 서식 > 줄 간격 > 1.0 */
		private void menuStrip_Form_Space_10_Click(object sender, EventArgs e)
		{
			// 줄 간격을 1.0으로 설정
			DefaultCharOffset = -10;
			richTextBox.SelectionCharOffset = DefaultCharOffset;

			menuStrip_Form_Space_10.CheckState = CheckState.Checked;
			toolStrip_Down_Space_10.CheckState = CheckState.Checked;

			// 다른 줄 간격 버튼 체크 해제
			menuStrip_Form_Space_115.CheckState = CheckState.Unchecked;
			toolStrip_Down_Space_115.CheckState = CheckState.Unchecked;

			menuStrip_Form_Space_15.CheckState = CheckState.Unchecked;
			toolStrip_Down_Space_15.CheckState = CheckState.Unchecked;

			menuStrip_Form_Space_20.CheckState = CheckState.Unchecked;
			toolStrip_Down_Space_20.CheckState = CheckState.Unchecked;
		}

		/* 서식 > 줄 간격 > 1.15 */
		private void menuStrip_Form_Space_115_Click(object sender, EventArgs e)
		{
			// 줄 간격을 1.15으로 설정
			DefaultCharOffset = -11;
			richTextBox.SelectionCharOffset = DefaultCharOffset;

			menuStrip_Form_Space_115.CheckState = CheckState.Checked;
			toolStrip_Down_Space_115.CheckState = CheckState.Checked;

			// 다른 줄 간격 버튼 체크 해제
			menuStrip_Form_Space_10.CheckState = CheckState.Unchecked;
			toolStrip_Down_Space_10.CheckState = CheckState.Unchecked;

			menuStrip_Form_Space_115.CheckState = CheckState.Unchecked;
			toolStrip_Down_Space_115.CheckState = CheckState.Unchecked;

			menuStrip_Form_Space_20.CheckState = CheckState.Unchecked;
			toolStrip_Down_Space_20.CheckState = CheckState.Unchecked;
		}

		/* 서식 > 줄 간격 > 1.5 */
		private void menuStrip_Form_Space_15_Click(object sender, EventArgs e)
		{
			// 줄 간격을 1.5으로 설정
			DefaultCharOffset = -15;
			richTextBox.SelectionCharOffset = DefaultCharOffset;

			menuStrip_Form_Space_15.CheckState = CheckState.Checked;
			toolStrip_Down_Space_15.CheckState = CheckState.Checked;

			// 다른 줄 간격 버튼 체크 해제
			menuStrip_Form_Space_10.CheckState = CheckState.Unchecked;
			toolStrip_Down_Space_10.CheckState = CheckState.Unchecked;

			menuStrip_Form_Space_115.CheckState = CheckState.Unchecked;
			toolStrip_Down_Space_115.CheckState = CheckState.Unchecked;

			menuStrip_Form_Space_20.CheckState = CheckState.Unchecked;
			toolStrip_Down_Space_20.CheckState = CheckState.Unchecked;
		}

		/* 서식 > 줄 간격 > 2.0 */
		private void menuStrip_Form_Space_20_Click(object sender, EventArgs e)
		{
			// 줄 간격을 2.0으로 설정
			DefaultCharOffset = -20;
			richTextBox.SelectionCharOffset = DefaultCharOffset;

			menuStrip_Form_Space_20.CheckState = CheckState.Checked;
			toolStrip_Down_Space_20.CheckState = CheckState.Checked;

			// 다른 줄 간격 버튼 체크 해제
			menuStrip_Form_Space_10.CheckState = CheckState.Unchecked;
			toolStrip_Down_Space_10.CheckState = CheckState.Unchecked;

			menuStrip_Form_Space_115.CheckState = CheckState.Unchecked;
			toolStrip_Down_Space_115.CheckState = CheckState.Unchecked;

			menuStrip_Form_Space_15.CheckState = CheckState.Unchecked;
			toolStrip_Down_Space_15.CheckState = CheckState.Unchecked;
		}

		/* 서식 > 텍스트 맞춤 > 왼쪽 맞춤 */
		private void menuStrip_Form_Align_Left_Click(object sender, EventArgs e)
		{
			// 왼쪽 맞춤 실행
			richTextBox.SelectionAlignment = HorizontalAlignment.Left;

			menuStrip_Form_Align_Left.CheckState = CheckState.Checked;
			toolStrip_Down_AlignLeft.CheckState = CheckState.Checked;

			// 다른 텍스트 맞춤 버튼 체크 해제
			menuStrip_Form_Align_Center.CheckState = CheckState.Unchecked;
			toolStrip_Down_AlignCenter.CheckState = CheckState.Unchecked;

			menuStrip_Form_Align_Right.CheckState = CheckState.Unchecked;
			toolStrip_Down_AlignRight.CheckState = CheckState.Unchecked;

			menuStrip_Form_Align_Justify.CheckState = CheckState.Unchecked;
			toolStrip_Down_AlignJustify.CheckState = CheckState.Unchecked;
		}

		/* 서식 > 텍스트 맞춤 > 가운데 맞춤 */
		private void menuStrip_Form_Align_Center_Click(object sender, EventArgs e)
		{
			// 가운데 맞춤 실행
			richTextBox.SelectionAlignment = HorizontalAlignment.Center;

			menuStrip_Form_Align_Center.CheckState = CheckState.Checked;
			toolStrip_Down_AlignCenter.CheckState = CheckState.Checked;

			// 다른 텍스트 맞춤 버튼 체크 해제
			menuStrip_Form_Align_Left.CheckState = CheckState.Unchecked;
			toolStrip_Down_AlignLeft.CheckState = CheckState.Unchecked;

			menuStrip_Form_Align_Right.CheckState = CheckState.Unchecked;
			toolStrip_Down_AlignRight.CheckState = CheckState.Unchecked;

			menuStrip_Form_Align_Justify.CheckState = CheckState.Unchecked;
			toolStrip_Down_AlignJustify.CheckState = CheckState.Unchecked;
		}

		/* 서식 > 텍스트 맞춤 > 오른쪽 맞춤 */
		private void menuStrip_Form_Align_Right_Click(object sender, EventArgs e)
		{
			// 오른쪽 맞춤 실행
			richTextBox.SelectionAlignment = HorizontalAlignment.Right;

			menuStrip_Form_Align_Right.CheckState = CheckState.Checked;
			toolStrip_Down_AlignRight.CheckState = CheckState.Checked;

			// 다른 텍스트 맞춤 버튼 체크 해제
			menuStrip_Form_Align_Left.CheckState = CheckState.Unchecked;
			toolStrip_Down_AlignLeft.CheckState = CheckState.Unchecked;

			menuStrip_Form_Align_Center.CheckState = CheckState.Unchecked;
			toolStrip_Down_AlignCenter.CheckState = CheckState.Unchecked;

			menuStrip_Form_Align_Justify.CheckState = CheckState.Unchecked;
			toolStrip_Down_AlignJustify.CheckState = CheckState.Unchecked;
		}

		/* 서식 > 텍스트 맞춤 > 양쪽 맞춤 */
		private void menuStrip_Form_Align_Justify_Click(object sender, EventArgs e)
		{
			// 양쪽 맞춤 실행
			richTextBox.SelectionAlignment = HorizontalAlignment.Left;

			menuStrip_Form_Align_Justify.CheckState = CheckState.Checked;
			toolStrip_Down_AlignJustify.CheckState = CheckState.Checked;

			// 다른 텍스트 맞춤 버튼 체크 해제
			menuStrip_Form_Align_Left.CheckState = CheckState.Unchecked;
			toolStrip_Down_AlignLeft.CheckState = CheckState.Unchecked;

			menuStrip_Form_Align_Center.CheckState = CheckState.Unchecked;
			toolStrip_Down_AlignCenter.CheckState = CheckState.Unchecked;

			menuStrip_Form_Align_Right.CheckState = CheckState.Unchecked;
			toolStrip_Down_AlignRight.CheckState = CheckState.Unchecked;
		}

		/* 서식 > 단락 기호 */
		private void menuStrip_Form_ParaChar_Click(object sender, EventArgs e)
		{
			MessageBox.Show("아직 개발 중 입니다!");
		}

		/* 삽입 > 사진 > 사진 */
		private void menuStrip_Insert_Image_Insert_Click(object sender, EventArgs e)
		{
			openFileDialog_Image.FileName = "";
			openFileDialog_Image.Filter = "BMP (*.BMP)|*.BMP|JPG (*.JPG)|*.JPG|JPEG (*.JPEG)|*.JPEG|PNG (*.PNG)|*.PNG|모든 파일 (*.*)|*.*";
			openFileDialog_Image.DefaultExt = "*.*";

			if (openFileDialog_Image.ShowDialog() == DialogResult.OK)
			{
				Image img = Image.FromFile(openFileDialog_Image.FileName);

				Clipboard.SetImage(img);
				richTextBox.Paste();
			}

			menuStrip_Insert.HideDropDown();
		}

		/* 삽입 > 사진 > 사진 변경 */
		private void menuStrip_Insert_Image_Change_Click(object sender, EventArgs e)
		{
			MessageBox.Show("아직 개발 중 입니다!");
		}

		/* 삽입 > 사진 > 사진 크기 조정 */
		private void menuStrip_Insert_Image_Resize_Click(object sender, EventArgs e)
		{
			MessageBox.Show("아직 개발 중 입니다!");
		}

		/* 삽입 > 스크린샷 */
		private void menuStrip_Insert_ScreenShot_Click(object sender, EventArgs e)
		{
			MessageBox.Show("아직 개발 중 입니다!");
		}

		/* 삽입 > 도형 */
		private void menuStrip_Insert_Draw_Click(object sender, EventArgs e)
		{
			MessageBox.Show("아직 개발 중 입니다!");
		}

		/* 보기 > 확대 */
		private void menuStrip_View_ZoomIn_Click(object sender, EventArgs e)
		{
			if ((richTextBox.ZoomFactor + 0.5f) <= 64)
			{
				richTextBox.ZoomFactor += 0.5f;

				richTextBox.Width = (int)(richTextBox.Width * 1.5);

				if (richTextBox.Width < Width)
				{
					int newPadding = (Width - richTextBox.Width) / 2;
					richTextBox.Left = newPadding;
				}
				else
					richTextBox.Left = 0;
			}
		}

		/* 보기 > 축소 */
		private void menuStrip_View_ZoomOut_Click(object sender, EventArgs e)
		{
			if ((richTextBox.ZoomFactor - 0.5f) > (1 / 64))
			{
				richTextBox.ZoomFactor -= 0.5f;

				richTextBox.Width = (int)(richTextBox.Width * (2f / 3f));

				if (richTextBox.Width > Width)
					richTextBox.Left = 0;
				else
				{
					int newPadding = (Width - richTextBox.Width) / 2;
					richTextBox.Left = newPadding;
				}
			}
		}

		/* 보기 > 100% */
		private void menuStrip_View_ZoomDefault_Click(object sender, EventArgs e)
		{
			richTextBox.ZoomFactor = 1;

			AutoResizePanel();
		}

		/* 보기 > 눈금자 */
		private void menuStrip_View_Ruler_CheckStateChanged(object sender, EventArgs e)
		{
			AutoResizePanel();
		}

		/* 보기 > 상태 표시줄 */
		private void menuStrip_View_Statusbar_CheckStateChanged(object sender, EventArgs e)
		{
			if (menuStrip_View_Statusbar.CheckState == CheckState.Checked)
				statusStrip.Visible = true;
			else if (menuStrip_View_Statusbar.CheckState == CheckState.Unchecked)
				statusStrip.Visible = false;
		}

		/* 보기 > 자동 줄 바꿈 */
		private void menuStrip_View_AutoWrap_CheckStateChanged(object sender, EventArgs e)
		{
			if (menuStrip_View_AutoWrap.CheckState == CheckState.Checked)
				richTextBox.WordWrap = true;
			else if (menuStrip_View_AutoWrap.CheckState == CheckState.Unchecked)
				richTextBox.WordWrap = false;
		}

		/* 보기 > 관용구 하이라이팅 */
		private void menuStrip_View_Syntax_Click(object sender, EventArgs e)
		{
			if (menuStrip_View_Syntax.CheckState == CheckState.Checked)
			{
				SyntaxHighlight();

				toolStrip_Down_Syntax.CheckState = CheckState.Checked;
			}
			else if (menuStrip_View_Syntax.CheckState == CheckState.Unchecked)
			{
				SyntaxHighlight();

				toolStrip_Down_Syntax.CheckState = CheckState.Unchecked;
			}
		}

		/* 글꼴 변경 */
		private void toolStrip_Up_FontList_TextChanged(object sender, EventArgs e)
		{
			AutoChangeFont();
		}

		/* 글꼴 크기 변경 */
		private void toolStrip_Up_FontSize_TextChanged(object sender, EventArgs e)
		{
			AutoChangeFont();
		}

		/* 굵게 */
		private void toolStrip_Up_Bold_Click(object sender, EventArgs e)
		{
			AutoChangeFont();
		}

		/* 기울임꼴 */
		private void toolStrip_Up_Italic_Click(object sender, EventArgs e)
		{
			AutoChangeFont();
		}

		/* 밑줄 */
		private void toolStrip_Up_Underline_Click(object sender, EventArgs e)
		{
			AutoChangeFont();
		}

		/* 취소선 */
		private void toolStrip_Up_Strikeout_Click(object sender, EventArgs e)
		{
			AutoChangeFont();
		}

		/* 텍스트 강조 색 */
		private void toolStrip_Up_Highlight_Click(object sender, EventArgs e)
		{
			if (toolStrip_Up_Highlight.CheckState == CheckState.Checked)
			{
				richTextBox.SelectionBackColor = colorDialog_Highlight.Color;

				menuStrip_Form_Highlight.CheckState = CheckState.Checked;
			}
			else if (toolStrip_Up_Highlight.CheckState == CheckState.Unchecked)
			{
				richTextBox.SelectionBackColor = Color.Transparent;

				menuStrip_Form_Highlight.CheckState = CheckState.Unchecked;
			}
		}

		/* 아래 첨자 */
		private void toolStrip_Up_Down_Click(object sender, EventArgs e)
		{
			// 버튼이 체크 상태일 때, 아래 첨자 실행
			// 버튼이 해제 상태일 때, 아래 첨자 해제
			if (toolStrip_Up_Down.CheckState == CheckState.Checked)
			{
				richTextBox.SelectionCharOffset = DefaultCharOffset;
				richTextBox.SelectionCharOffset -= 3;

				menuStrip_Form_Down.CheckState = CheckState.Checked;

				menuStrip_Form_Up.CheckState = CheckState.Unchecked;
				toolStrip_Up_Up.CheckState = CheckState.Unchecked;
			}
			else if (toolStrip_Up_Down.CheckState == CheckState.Unchecked)
			{
				richTextBox.SelectionCharOffset = DefaultCharOffset;

				toolStrip_Up_Down.CheckState = CheckState.Unchecked;
			}
		}

		/* 위 첨자 */
		private void toolStrip_Up_Up_Click(object sender, EventArgs e)
		{
			// 버튼이 체크 상태일 때, 위 첨자 실행
			// 버튼이 해제 상태일 때, 위 첨자 해제
			if (toolStrip_Up_Up.CheckState == CheckState.Checked)
			{
				richTextBox.SelectionCharOffset = DefaultCharOffset;
				richTextBox.SelectionCharOffset += 3;

				menuStrip_Form_Up.CheckState = CheckState.Checked;

				menuStrip_Form_Down.CheckState = CheckState.Unchecked;
				toolStrip_Up_Down.CheckState = CheckState.Unchecked;
			}
			else if (toolStrip_Up_Up.CheckState == CheckState.Unchecked)
			{
				richTextBox.SelectionCharOffset = DefaultCharOffset;

				menuStrip_Form_Up.CheckState = CheckState.Unchecked;
			}
		}

		/* 글머리 기호 */
		private void toolStrip_Down_ListBullet_Click(object sender, EventArgs e)
		{
			if (toolStrip_Down_ListBullet.CheckState == CheckState.Checked)
			{
				menuStrip_Form_IndentIncrease_Click(null, null);
				richTextBox.SelectionBullet = true;

				menuStrip_Form_List.CheckState = CheckState.Checked;
				menuStrip_Form_List_Bullet.CheckState = CheckState.Checked;
			}
			else if (toolStrip_Down_ListBullet.CheckState == CheckState.Unchecked)
			{
				menuStrip_Form_IndentDecrease_Click(null, null);
				richTextBox.SelectionBullet = false;

				menuStrip_Form_List.CheckState = CheckState.Unchecked;
				menuStrip_Form_List_Bullet.CheckState = CheckState.Unchecked;
			}
		}

		/* 관용구 하이라이팅 */
		private void toolStrip_Down_Syntax_Click(object sender, EventArgs e)
		{
			if (toolStrip_Down_Syntax.CheckState == CheckState.Checked)
			{
				SyntaxHighlight();

				menuStrip_View_Syntax.CheckState = CheckState.Checked;
			}
			else if (toolStrip_Down_Syntax.CheckState == CheckState.Unchecked)
			{
				SyntaxHighlight();

				menuStrip_View_Syntax.CheckState = CheckState.Unchecked;
			}
		}

		private void richTextBox_SelectionChanged(object sender, EventArgs e)
		{
			AutoReflectFont();
		}

		private void richTextBox_TextChanged(object sender, EventArgs e)
		{
			IsTextChanged = true;

			if (menuStrip_View_Syntax.CheckState == CheckState.Checked)
				SyntaxHighlight();
		}

		/* 왼쪽 여백 조절 이미지 마우스 클릭 */
		private void pictureBox_Bar_Left_MouseDown(object sender, MouseEventArgs e)
		{
			Mouse_Click = true;
		}

		/* 왼쪽 여백 조절 이미지 마우스 클릭 해제 */
		private void pictureBox_Bar_Left_MouseUp(object sender, MouseEventArgs e)
		{
			Mouse_Click = false;
		}

		/* 왼쪽 여백 조절 이미지 위치 조정 */
		private void pictureBox_Bar_Left_MouseMove(object sender, MouseEventArgs e)
		{
			int x = Cursor.Position.X;
			int liminMin = pictureBox_Ruler.Location.X;
			int limitMax = pictureBox_Bar_Right.Location.X;

			if (Mouse_Click == true)
			{
				if (x >= liminMin && x <= limitMax)
				{
					pictureBox_Bar_Left.Location = new Point(x, pictureBox_Bar_Left.Location.Y);
					Margin_Left = x - panel.Location.X;
					panel.Padding = new Padding(Margin_Left, Margin_Top, Margin_Right, Margin_Bottom);
				}
			}
		}

		/* 오른쪽 여백 조절 이미지 마우스 클릭 */
		private void pictureBox_Bar_Right_MouseDown(object sender, MouseEventArgs e)
		{
			Mouse_Click = true;
		}

		/* 오른쪽 여백 조절 이미지 마우스 클릭 해제 */
		private void pictureBox_Bar_Right_MouseUp(object sender, MouseEventArgs e)
		{
			Mouse_Click = false;
		}

		/* 오른쪽 여백 조절 이미지 위치 조정 */
		private void pictureBox_Bar_Right_MouseMove(object sender, MouseEventArgs e)
		{
			int x = Cursor.Position.X;
			int liminMin = pictureBox_Bar_Left.Location.X;
			int limitMax = pictureBox_Ruler.Location.X + pictureBox_Ruler.Width - pictureBox_Bar_Right.Width;

			if (Mouse_Click == true)
			{
				if (x >= liminMin && x <= limitMax)
				{
					pictureBox_Bar_Right.Location = new Point(x, pictureBox_Bar_Right.Location.Y);
					Margin_Right = (panel.Location.X + panel.Width) - x;
					panel.Padding = new Padding(Margin_Left, Margin_Top, Margin_Right, Margin_Bottom);
				}
			}
		}
		
		/* 초기화 함수 */
		private void MyInit()
		{
			// 현재 해상도에 따라 초기 창 크기 조절
			Width = (int)(Screen.PrimaryScreen.Bounds.Width * 0.5);
			Height = (int)(Width * 0.75);

			// DPI를 구하고, 그에 따라 아이콘 크기 수정
			Graphics graphics = CreateGraphics();
			float dpi = graphics.DpiX;

			double percent = dpi / 96;
			int menuIconSize = (int)(48 * percent);
			int toolIconSize = (int)(24 * percent);

			menuStrip.ImageScalingSize = new Size(menuIconSize, menuIconSize);
			toolStrip_Up.ImageScalingSize = new Size(toolIconSize, toolIconSize);
			toolStrip_Down.ImageScalingSize = new Size(toolIconSize, toolIconSize);

			menuStrip_Form_Highligt_Color.Height = menuIconSize + 6;
			menuStrip_Form_List_Bullet.Height = menuIconSize + 6;
			menuStrip_Form_List_Number.Height = menuIconSize + 6;
			menuStrip_Form_Align_Left.Height = menuIconSize + 6;
			menuStrip_Form_Align_Center.Height = menuIconSize + 6;
			menuStrip_Form_Align_Right.Height = menuIconSize + 6;
			menuStrip_Form_Align_Justify.Height = menuIconSize + 6;
			menuStrip_Insert_Image_Insert.Height = menuIconSize + 6;
			menuStrip_Insert_Image_Change.Height = menuIconSize + 6;
			menuStrip_Insert_Image_Resize.Height = menuIconSize + 6;

			// 파일 변수 설정
			FilePath = "";
			FileName = "문서.rtf";
			FileType = ".rtf";

			// 폰트 리스트 로드
			toolStrip_Up_FontList.Items.AddRange(FontFamily.Families.Select(f => f.Name).ToArray());

			// OpenFileDialog 설정
			openFileDialog_File.FileName = "";
			openFileDialog_File.Filter = "서식있는 텍스트 (*.rtf)|*.rtf|텍스트 문서(*.txt)|*.txt|모든 파일 (*.*)|*.*";
			openFileDialog_File.DefaultExt = "*.rtf";

			// SaveFileDialog 설정
			saveFileDialog.FileName = "";
			saveFileDialog.Filter = "서식있는 텍스트 (*.rtf)|*.rtf|텍스트 문서(*.txt)|*.txt|모든 파일 (*.*)|*.*";
			saveFileDialog.DefaultExt = "*.rtf";

			// 용지 방향 설정
			PageType = 0;

			// 여백 설정
			Margin_Top = 0;
			Margin_Bottom = 0;
			Margin_Left = 0;
			Margin_Right = 0;

			panel.Padding = new Padding(Margin_Left, Margin_Top, Margin_Right, Margin_Bottom);

			// RichTextBox 설정
			richTextBox.Font = new Font("맑은 고딕", 9);
			richTextBox.SelectionCharOffset = DefaultCharOffset = -11;
			richTextBox.LanguageOption = 0;
			IsTextChanged = false;

			Text = "문서 - WordPad#";
		}

		/* 창크기에 따라 자동으로 Panel 크기 조절 */
		private void AutoResizePanel()
		{
			int x;
			int y;

			Graphics graphics = CreateGraphics();
			float dpi = graphics.DpiX;

			double percent = dpi / 96;
			int barHeight = (int)(24 * percent);

			switch (PageType)
			{
				case 0:
					DefaultWidth = (int)Width / 2;
					DefaultHeight = Height;
					break;

				case 1:
					DefaultWidth = (int)Width / 3 * 2;
					DefaultHeight = Height;
					break;

				default:
					break;
			}

			panel.Width = DefaultWidth;
			panel.Height = DefaultHeight;

			pictureBox_Ruler.Width = DefaultWidth;
			pictureBox_Ruler.Height = barHeight;

			switch (menuStrip_View_Ruler.CheckState)
			{
				case CheckState.Unchecked:
					x = (Width - panel.Width) / 2;
					y = menuStrip.Height + toolStrip_Up.Height + toolStrip_Down.Height + 6;
					pictureBox_Ruler.Visible = false;
					pictureBox_Bar_Left.Visible = false;
					pictureBox_Bar_Right.Visible = false;
					panel.Location = new Point(x, y);
					break;

				case CheckState.Checked:
					x = (Width - panel.Width) / 2;
					y = menuStrip.Height + toolStrip_Up.Height + toolStrip_Down.Height + 6;
					pictureBox_Ruler.Location = new Point(x, y);
					pictureBox_Bar_Left.Location = new Point(x + Margin_Left, y);
					pictureBox_Bar_Right.Location = new Point(x + DefaultWidth - pictureBox_Bar_Right.Width - Margin_Right, y);
					pictureBox_Ruler.Visible = true;
					pictureBox_Bar_Left.Visible = true;
					pictureBox_Bar_Right.Visible = true;
					panel.Location = new Point(x, y + pictureBox_Ruler.Height + 6);
					break;

				default:
					break;
			}
		}

		/* toolStrip 버튼들의 체크 상태에 따라 자동으로 폰트 수정 */
		private void AutoChangeFont()
		{
			try
			{
				Font font = new Font
				(
					Convert.ToString(toolStrip_Up_FontList.SelectedItem),
					float.Parse(Convert.ToString(toolStrip_Up_FontSize.SelectedItem)),
					(toolStrip_Up_Bold.Checked ? FontStyle.Bold : FontStyle.Regular)
					| (toolStrip_Up_Italic.Checked ? FontStyle.Italic : FontStyle.Regular)
					| (toolStrip_Up_Strikeout.Checked ? FontStyle.Strikeout : FontStyle.Regular)
					| (toolStrip_Up_Underline.Checked ? FontStyle.Underline : FontStyle.Regular)
				);

				richTextBox.SelectionFont = font;
			}
			catch (Exception)
			{
				MessageBox.Show("폰트를 적용하는 도중에 오류가 발생했습니다!");
			}
		}

		/* 폰트 속성에 따라서 자동으로 toolStrip 버튼 체크 상태를 변경 */
		private void AutoReflectFont()
		{
			Font font = richTextBox.SelectionFont;

			if (font == null)
				return;

			fontDialog.Font = font;

			toolStrip_Up_FontList.Text = Convert.ToString(font.Name);
			toolStrip_Up_FontSize.Text = Convert.ToString(font.Size);
			toolStrip_Up_Bold.Checked = font.Bold;
			toolStrip_Up_Italic.Checked = font.Italic;
			toolStrip_Up_Strikeout.Checked = font.Strikeout;
			toolStrip_Up_Underline.Checked = font.Underline;
		}

		/*  */
		private void SyntaxHighlight()
		{
			string keywords = "";

			if (FileType == ".c")
			{
				keywords = "(auto |double |int |struct |break |else |long |switch |case |enum |register |typedef |char |extern |return |union |const |float |short |unsigned |continue |for |signed |void |default |goto |sizeof |volatile |do |if |static |while |)";
			}
			else if (FileType == ".cpp" || FileType == ".cc")
			{
				keywords = "(alignas |alignof |and |and_eq |asm |auto |bitand |bitor |bool |break |case |catch |char |char16_t |char32_t |class |compl |const |constexpr |const_cast |continue |decltype |default |delete |do |double |dynamic_cast |else |enum |explicit |export(1) |extern |false |float |for |friend |goto |if |inline |int |long |mutable |namespace |new |noexcept |not |not_eq |nullptr |operator |or |or_eq |private |protected |public |register |reinterpret_cast |return |short |signed |sizeof |static |static_assert |static_cast |struct |switch |template |this |thread_local |throw |true |try |typedef |typeid |typename |union |unsigned |using |virtual |void |volatile |wchar_t |while |xor |xor_eq )";
			}
			else if (FileType == ".java")
			{
				keywords = "(abstract |boolean |break |byte |case |catch |char |class |const |continue |default |do |double |else |extends |final |finally |float |for |goto |if |implements |import |instanceof |int |interface |long |native |new |package |private |protected |public |return |short |static |strictfp |super |switch |synchronized |this |throw |throws |transient |try |void |volatile |while )";
			}

			Regex regex = new Regex(keywords, RegexOptions.Compiled);
			MatchCollection matchCollection = regex.Matches(richTextBox.Text);

			try
			{
				int startPosition = richTextBox.SelectionStart;

				foreach (Match item in matchCollection)
				{
					int start = item.Index;
					int stop = item.Length;

					richTextBox.Select(start, stop);
					richTextBox.SelectionColor = Color.Blue;
				}

				richTextBox.Select(startPosition, 0);
				richTextBox.SelectionColor = Color.Black;
			}
			finally
			{
				LockWindowUpdate(IntPtr.Zero);
			}
		}

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		private static extern bool LockWindowUpdate(IntPtr hWndLock);
	}
}