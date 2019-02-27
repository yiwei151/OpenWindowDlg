using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class Utils : MonoBehaviour {

    public void OnBtnClick()
    {
        string path = SaveProject();
        Debug.Log("路径：" + path);
    }

    #region 打开窗口对话框
    /// <summary>
    /// 打开窗口 对话框
    /// </summary>
    /// <returns></returns>
    public static string OpenWindowDlg()
    {
        OpenFileDlg pth = new OpenFileDlg();

        pth.structSize = System.Runtime.InteropServices.Marshal.SizeOf(pth);
        pth.filter = "Excel文件(*.xlsx)\0*.xlsx";
        pth.file = new string(new char[256]);
        pth.maxFile = pth.file.Length;
        pth.fileTitle = new string(new char[64]);
        pth.maxFileTitle = pth.fileTitle.Length;
        pth.initialDir = Application.dataPath;  // default path  
        pth.title = "打开Excel文件";
        pth.defExt = "xlsx";
        pth.flags = 0x00080000 | 0x00001000 | 0x00000800 | 0x00000008;

        //flags的意义，网址链接：https://docs.microsoft.com/zh-cn/windows/desktop/api/commdlg/ns-commdlg-tagofna
        //0x00080000  是否使用新版文件选择窗口
        //0x00000200  是否可以多选

        if (OpenFileDialog.GetOpenFileName(pth))
        {
            string filepath = pth.file;//选择的文件路径;  

            return filepath;
        }
        else
        {
            Debug.Log("没有选择文件");
        }
        return string.Empty;
    }
    /// <summary>
    /// 保存文件对话框
    /// </summary>
    public static string SaveProject()
    {
        SaveFileDlg pth = new SaveFileDlg();
        pth.structSize = System.Runtime.InteropServices.Marshal.SizeOf(pth);
        pth.filter = "Excel文件(*.xlsx)\0*.xlsx";
        pth.file = new string(new char[256]);
        pth.maxFile = pth.file.Length;
        pth.fileTitle = new string(new char[64]);
        pth.maxFileTitle = pth.fileTitle.Length;
        pth.initialDir = Application.dataPath;  // default path  
        pth.title = "保存Excel文件";
        pth.defExt = "xlsx";
        pth.file = "打开窗口后的默认文件名称";
        pth.flags = 0x00080000 | 0x00001000 | 0x00000800 | 0x00000200 | 0x00000008;
        if (SaveFileDialog.GetSaveFileName(pth))
        {
            string filepath = pth.file;//选择的文件路径;  
            Debug.Log(filepath);

            return filepath;
        }

        return "";
    }
    #endregion

}
