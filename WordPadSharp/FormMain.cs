using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordPadSharp
{
    public partial class FormMain : System.Windows.Forms.Form
    {
        private String FilePath = null;		// 현재 파일의 경로
        private String FileName = null;		// 현재 파일의 이름
        private String FileType = null;     // 현재 파일의 형식

        private bool IsTextChanged = false;

        private int DefaultCharOffset = -11;

        public FormMain()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            // 파일 변수 설정
            FilePath = "";
            FileName = "문서.rtf";
            FileType = ".rtf";

            // 폰트 리스트 로드
            toolStrip_Up_FontList.Items.AddRange(FontFamily.Families.Select(f => f.Name).ToArray());

            // OpenFileDialog 설정
            openFileDialog.FileName = "";
            openFileDialog.Filter = "서식있는 텍스트 (*.rtf)|*.rtf|텍스트 문서(*.txt)|*.txt|모든 파일 (*.*)|*.*";
            openFileDialog.DefaultExt = "*.rtf";

            // SaveFileDialog 설정
            saveFileDialog.FileName = "";
            saveFileDialog.Filter = "서식있는 텍스트 (*.rtf)|*.rtf|텍스트 문서(*.txt)|*.txt|모든 파일 (*.*)|*.*";
            saveFileDialog.DefaultExt = "*.rtf";

            // RichTextBox 설정
            // 이렇게 안하고 모든 폰트 관련 설정은 
            // 어차피 폰트 관련 UI와 같이 동기화 되어야하기 때문에
            // 순서를 항상
            // 폰트 관련 UI를 수정 -> 폰트 관련 UI 기반 richTextBox 수정
            /*
            richTextBox.Font = new Font("맑은 고딕", 9);
            richTextBox.SelectionCharOffset = DefaultCharOffset;
            */
            toolStrip_Up_FontList.SelectedIndex = 320; // 말근고딕임 ^^ ㅎ
            toolStrip_Up_FontSize.SelectedIndex = 1; // 9pt ? ㅎ ^^ ㅎ

            Text = "문서 - WordPad#";
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

            // 파일 변수 초기화
            FilePath = "";
            FileName = "문서.rtf";
            FileType = ".rtf";

            // OpenFileDialog & SaveFileDialog 초기화
            openFileDialog.FileName = "";
            saveFileDialog.FileName = "";

            // RichTextBox 초기화
            richTextBox.SelectionCharOffset = DefaultCharOffset;
            richTextBox.Text = "";
            IsTextChanged = false;

            Text = "문서 - WordPad#";
        }

        /* 파일 > 열기 */
        private void menuStrip_File_Open_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 여는 파일의 형식이 "*.rtf"인 경우
                    if (Path.GetExtension(openFileDialog.FileName) == ".rtf")
                    {
                        richTextBox.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.RichText);
                    }
                    // 그외의 경우
                    else
                    {
                        richTextBox.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
                    }

                    // 현재 파일 변수 설정
                    FilePath = Path.GetFullPath(openFileDialog.FileName);
                    FileName = Path.GetFileName(openFileDialog.FileName);
                    FileType = Path.GetExtension(openFileDialog.FileName);

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
            // 현재 열려있는 파일이 없는 경우
            if (openFileDialog.FileName == "")
            {
                saveFileDialog.FileName = FileName;

                if (saveFileDialog.ShowDialog() == DialogResult.OK && (saveFileDialog.FileName.Length > 0))
                {
                    // 파일의 저장 형식이 "*.rtf"인 경우
                    if (Path.GetExtension(saveFileDialog.FileName) == ".rtf")
                    {
                        richTextBox.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                    }
                    // 그외의 경우
                    else
                    {
                        richTextBox.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
                    }

                    openFileDialog.FileName = saveFileDialog.FileName;

                    // 현재 파일 변수 설정
                    FilePath = Path.GetFullPath(openFileDialog.FileName);
                    FileName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                    FileType = Path.GetExtension(openFileDialog.FileName);

                    Text = FileName + " - WordPad#";
                }
            }
            // 현재 열려있는 파일이 있는 경우
            else
            {
                // 현재 열려있는 파일의 형식이 "*.rtf"인 경우
                if (FileType == ".rtf")
                {
                    richTextBox.SaveFile(openFileDialog.FileName, RichTextBoxStreamType.RichText);
                }
                // 그외의 경우
                else
                {
                    richTextBox.SaveFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
                }
            }

            IsTextChanged = false;
        }

        /* 파일 > 다른 이름으로 저장 */
        private void menuStrip_File_SaveAs_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK && (saveFileDialog.FileName.Length > 0))
            {
                // 파일의 저장 형식이 "*.rtf"인 경우
                if (Path.GetExtension(saveFileDialog.FileName) == ".rtf")
                {
                    richTextBox.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                }
                // 그외의 경우
                else
                {
                    richTextBox.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
                }
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
            MessageBox.Show("아직 개발 중 입니다!");
        }

        /* 파일 > 전자 메일로 보내기 */
        private void menuStrip_File_Mail_Click(object sender, EventArgs e)
        {
            MessageBox.Show("아직 개발 중 입니다!");
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
            // 현재 작업 중인 파일의 형식이 "rtf"인 경우
            if (FileType == ".rtf")
            {
                richTextBox.Paste();
            }
            // 그외인 경우
            else
            {
                richTextBox.AppendText(Clipboard.GetText());
            }
        }

        /* 편집 > 찾기 */
        private void menuStrip_Edit_Find_Click(object sender, EventArgs e)
        {
            MessageBox.Show("아직 개발 중 입니다!");
        }

        /* 편집 > 바꾸기 */
        private void menuStrip_Edit_Replace_Click(object sender, EventArgs e)
        {
            MessageBox.Show("아직 개발 중 입니다!");
        }

        /* 편집 > 모두 선택 */
        private void menuStrip_Edit_SelectAll_Click(object sender, EventArgs e)
        {
            richTextBox.SelectAll();
        }

        /* 편집 > 시간/날짜 */
        private void menuStrip_Edit_Date_Click(object sender, EventArgs e)
        {
            MessageBox.Show("아직 개발 중 입니다!");
        }

        /* 서식 > 글꼴 */
        private void menuStrip_Form_Font_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox.SelectionFont = fontDialog.Font;

                toolStrip_Up_FontList.Text = fontDialog.Font.Name;
                toolStrip_Up_FontSize.Text = Convert.ToString(fontDialog.Font.Size);

                // Bold
                if (fontDialog.Font.Bold == true)
                {
                    toolStrip_Up_Bold.CheckState = CheckState.Checked;
                }
                else
                {
                    toolStrip_Up_Bold.CheckState = CheckState.Unchecked;
                }

                // Italic
                if (fontDialog.Font.Italic == true)
                {
                    toolStrip_Up_Italic.CheckState = CheckState.Checked;
                }
                else
                {
                    toolStrip_Up_Italic.CheckState = CheckState.Unchecked;
                }

                // Underline
                if (fontDialog.Font.Underline == true)
                {
                    toolStrip_Up_Underline.CheckState = CheckState.Checked;
                }
                else
                {
                    toolStrip_Up_Underline.CheckState = CheckState.Checked;
                }

                // Strikeout
                if (fontDialog.Font.Strikeout)
                {
                    toolStrip_Up_Strikeout.CheckState = CheckState.Checked;
                }
                else
                {
                    toolStrip_Up_Strikeout.CheckState = CheckState.Unchecked;
                }
            }
        }

        /* 서식 > 아래 첨자 */
        private void menuStrip_Form_Down_Click(object sender, EventArgs e)
        {
            // 버튼이 체그 상태일 때
            if (menuStrip_Form_Down.CheckState == CheckState.Checked)
            {
                // 아래 첨자 실행
                richTextBox.SelectionCharOffset = DefaultCharOffset;
                richTextBox.SelectionCharOffset -= 3;

                toolStrip_Up_Down.CheckState = CheckState.Checked;

                menuStrip_Form_Up.CheckState = CheckState.Unchecked;
                toolStrip_Up_Up.CheckState = CheckState.Unchecked;
            }
            // 버튼이 체크 해제 상태일 때
            else if (menuStrip_Form_Down.CheckState == CheckState.Unchecked)
            {
                // 아래 첨자 해제
                richTextBox.SelectionCharOffset = DefaultCharOffset;

                toolStrip_Up_Down.CheckState = CheckState.Unchecked;
            }
        }

        /* 서식 > 위 첨자 */
        private void menuStrip_Form_Up_Click(object sender, EventArgs e)
        {
            // 버튼이 체크 상태일 때
            if (menuStrip_Form_Up.CheckState == CheckState.Checked)
            {
                // 위 첨자 실행
                richTextBox.SelectionCharOffset = DefaultCharOffset;
                richTextBox.SelectionCharOffset += 3;

                toolStrip_Up_Up.CheckState = CheckState.Checked;

                menuStrip_Form_Down.CheckState = CheckState.Unchecked;
                toolStrip_Up_Down.CheckState = CheckState.Unchecked;
            }
            // 버튼이 체크 해제 상태일 때
            else if (menuStrip_Form_Up.CheckState == CheckState.Unchecked)
            {
                // 위 첨자 해제
                richTextBox.SelectionCharOffset = DefaultCharOffset;

                toolStrip_Up_Up.CheckState = CheckState.Unchecked;
            }
        }

        /* 서식 > 텍스트 강조 색 */
        private void menuStrip_Form_Highlight_Click(object sender, EventArgs e)
        {
            // 버튼이 체크 상태일 때
            if (menuStrip_Form_Highlight.CheckState == CheckState.Checked)
            {
                // 텍스트 강조 실행
                richTextBox.SelectionBackColor = colorDialog.Color;

                toolStrip_Up_Highlight.CheckState = CheckState.Checked;
            }
            // 버튼이 체크 해제 상태일 때
            else if (menuStrip_Form_Highlight.CheckState == CheckState.Unchecked)
            {
                // 텍스트 강조 해제
                richTextBox.SelectionBackColor = Color.Transparent;

                toolStrip_Up_Highlight.CheckState = CheckState.Unchecked;
            }

            menuStrip_Form.HideDropDown();
        }

        /* 서식 > 텍스트 강조 색 > 색상 변경 */
        private void menuStrip_Form_Highligt_Color_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox.SelectionBackColor = colorDialog.Color;

                menuStrip_Form_Highlight.CheckState = CheckState.Checked;
                toolStrip_Up_Highlight.CheckState = CheckState.Checked;
            }
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
            MessageBox.Show("아직 개발 중 입니다!");

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
                int new_padding = (this.Width - richTextBox.Width) / 2;
                richTextBox.Left = new_padding; 
            }
        }

        /* 보기 > 축소 */
        private void menuStrip_View_ZoomOut_Click(object sender, EventArgs e)
        {
            if ((richTextBox.ZoomFactor - 0.5f) > (1 / 64))
            {
                richTextBox.ZoomFactor -= 0.5f;
                richTextBox.Width = (int)(richTextBox.Width * (2f/3f));
                int new_padding = (this.Width - richTextBox.Width) / 2;
                richTextBox.Left = new_padding; 
            }
        }

        /* 보기 > 100% */
        private void menuStrip_View_ZoomDefault_Click(object sender, EventArgs e)
        {
            richTextBox.ZoomFactor = 1;
        }

        /* 보기 > 눈금자 */
        private void menuStrip_View_Ruler_CheckStateChanged(object sender, EventArgs e)
        {
            if (menuStrip_View_Ruler.CheckState == CheckState.Checked)
            {
                MessageBox.Show("아직 개발 중 입니다!");
            }
            else if (menuStrip_View_Ruler.CheckState == CheckState.Unchecked)
            {
                MessageBox.Show("아직 개발 중 입니다!");
            }
        }

        /* 보기 > 상태 표시줄 */
        private void menuStrip_View_Statusbar_CheckStateChanged(object sender, EventArgs e)
        {
            if (menuStrip_View_Statusbar.CheckState == CheckState.Checked)
            {
                statusStrip.Visible = true;
            }
            else if (menuStrip_View_Statusbar.CheckState == CheckState.Unchecked)
            {
                statusStrip.Visible = false;
            }
        }

        /* 보기 > 자동 줄 바꿈 */
        private void menuStrip_View_AutoWrap_CheckStateChanged(object sender, EventArgs e)
        {
            if (menuStrip_View_AutoWrap.CheckState == CheckState.Checked)
            {
                richTextBox.WordWrap = true;
            }
            else if (menuStrip_View_AutoWrap.CheckState == CheckState.Unchecked)
            {
                richTextBox.WordWrap = false;
            }
        }

        /* 보기 > 관용구 하이라이팅 */
        private void menuStrip_View_Syntax_Click(object sender, EventArgs e)
        {
            if (menuStrip_View_Syntax.CheckState == CheckState.Checked)
            {
                MessageBox.Show("아직 개발 중 입니다!");

                toolStrip_Down_Syntax.CheckState = CheckState.Checked;
            }
            else if (menuStrip_View_Syntax.CheckState == CheckState.Unchecked)
            {
                MessageBox.Show("아직 개발 중 입니다!");

                toolStrip_Down_Syntax.CheckState = CheckState.Unchecked;
            }
        }

        /* 글꼴 변경 */
        private void toolStrip_Up_FontList_TextChanged(object sender, EventArgs e)
        {

        }

        /* 글꼴 크기 변경 */
        private void toolStrip_Up_FontSize_TextChanged(object sender, EventArgs e)
        {

        }

        /* 굵게 */
        private void toolStrip_Up_Bold_Click(object sender, EventArgs e)
        {

        }

        /* 기울임꼴 */
        private void toolStrip_Up_Italic_Click(object sender, EventArgs e)
        {

        }

        /* 밑줄 */
        private void toolStrip_Up_Underline_Click(object sender, EventArgs e)
        {

        }

        /* 취소선 */
        private void toolStrip_Up_Strikeout_Click(object sender, EventArgs e)
        {

        }

        /* 텍스트 강조 색 */
        private void toolStrip_Up_Highlight_Click(object sender, EventArgs e)
        {
            if (toolStrip_Up_Highlight.CheckState == CheckState.Checked)
            {
                richTextBox.SelectionBackColor = colorDialog.Color;

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
            if (toolStrip_Up_Down.CheckState == CheckState.Checked)
            {
                // 아래 첨자 실행
                richTextBox.SelectionCharOffset = DefaultCharOffset;
                richTextBox.SelectionCharOffset -= 3;

                menuStrip_Form_Down.CheckState = CheckState.Checked;

                menuStrip_Form_Up.CheckState = CheckState.Unchecked;
                toolStrip_Up_Up.CheckState = CheckState.Unchecked;
            }
            else if (toolStrip_Up_Down.CheckState == CheckState.Unchecked)
            {
                // 아래 첨자 해제
                richTextBox.SelectionCharOffset = DefaultCharOffset;

                toolStrip_Up_Down.CheckState = CheckState.Unchecked;
            }
        }

        /* 위 첨자 */
        private void toolStrip_Up_Up_Click(object sender, EventArgs e)
        {
            // 버튼이 체크 상태일 때
            if (toolStrip_Up_Up.CheckState == CheckState.Checked)
            {
                // 위 첨자 실행
                richTextBox.SelectionCharOffset = DefaultCharOffset;
                richTextBox.SelectionCharOffset += 3;

                menuStrip_Form_Up.CheckState = CheckState.Checked;

                menuStrip_Form_Down.CheckState = CheckState.Unchecked;
                toolStrip_Up_Down.CheckState = CheckState.Unchecked;
            }
            // 버튼이 체크 해제 상태일 때
            else if (toolStrip_Up_Up.CheckState == CheckState.Unchecked)
            {
                // 위 첨자 해제
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
                MessageBox.Show("아직 개발 중 입니다!");

                menuStrip_View_Syntax.CheckState = CheckState.Checked;
            }
            else if (toolStrip_Down_Syntax.CheckState == CheckState.Unchecked)
            {
                MessageBox.Show("아직 개발 중 입니다!");

                menuStrip_View_Syntax.CheckState = CheckState.Unchecked;
            }
        }

        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            IsTextChanged = true;
        }

        private void toolStrip_Up_FontList_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip_Up_FontList_SelectedIndexChanged(object sender, EventArgs e)
        { 
            changeFontAutomatically();
        }

        /// <summary>
        /// 자동으로 폰트 관련 toolStrip들의 값을 읽어 본문의 선택된 글에 적용합니다
        /// </summary>
        private void changeFontAutomatically()
        {
            try
            {
                Font f = new Font
                (
                    toolStrip_Up_FontList.SelectedItem.ToString(),
                    float.Parse(toolStrip_Up_FontSize.SelectedItem.ToString()),
                    (toolStrip_Up_Bold.Checked ? FontStyle.Bold : FontStyle.Regular)
                    | (toolStrip_Up_Italic.Checked ? FontStyle.Italic : FontStyle.Regular)
                    | (toolStrip_Up_Strikeout.Checked ? FontStyle.Strikeout : FontStyle.Regular)
                    | (toolStrip_Up_Underline.Checked ? FontStyle.Underline : FontStyle.Regular)
                );

                richTextBox.SelectionFont = f;
            }
            catch (Exception)
            {
                status("해당 폰트가 적절히 지원되지 않습니다");
            }
        }

        /// <summary>
        /// 자동으로 글의 폰트 관련 값들을 읽어 폰트 관련 toolStrip들의 값으로 반영합니다
        /// </summary>
        private void reflectFontAutomatically()
        {
            Font f = richTextBox.SelectionFont;
            if (f == null)
            {
                return;
            }

            toolStrip_Up_FontList.Text = f.FontFamily.ToString();
            toolStrip_Up_FontSize.Text = f.Size.ToString();
            toolStrip_Up_Bold.Checked = f.Bold;
            toolStrip_Up_Italic.Checked = f.Italic;
            toolStrip_Up_Strikeout.Checked = f.Strikeout;
            toolStrip_Up_Underline.Checked = f.Underline;
        }

        /// <summary>
        /// 상태바에 상태를 시간과 함께 기록합니다 - 이은찬
        /// </summary>
        /// <param name="obj">ToString()될 오브젝트... 암거나 다 넣어도댐 ㅋ</param>
        /// <returns>오류여부... 가끔 ToString()이 안되거나 오류날 수 있으니... ㅋ</returns>
        private bool status(object obj)
        {
            try
            {
                toolStripStatusLabel1.Text  = $"[{DateTime.Now.ToString()}]\t{obj.ToString()}";
                return true; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void toolStrip_Up_FontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeFontAutomatically();
        }

        private void toolStrip_Up_Bold_CheckedChanged(object sender, EventArgs e)
        {
            changeFontAutomatically();
        }

        private void toolStrip_Up_Italic_CheckedChanged(object sender, EventArgs e)
        {
            changeFontAutomatically();
        }

        private void toolStrip_Up_Underline_CheckedChanged(object sender, EventArgs e)
        {
            changeFontAutomatically();
        }

        private void toolStrip_Up_Strikeout_CheckedChanged(object sender, EventArgs e)
        {
            changeFontAutomatically();
        }

        private void richTextBox_SelectionChanged(object sender, EventArgs e)
        {
            reflectFontAutomatically();
        }

        private void toolStrip_Up_FontSize_TextChanged_1(object sender, EventArgs e)
        {
            changeFontAutomatically();
        }
    }
}