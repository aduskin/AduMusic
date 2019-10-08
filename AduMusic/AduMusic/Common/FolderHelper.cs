using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AduMusic.Common
{
    public class FolderHelper
    {
        #region 》获取文件夹下所有文件
       
        /// <summary>
        /// 获取文件夹下所有指定类型文件 
        /// </summary>
        /// <param name="sPath">文件夹路径</param>
        /// <param name="oFileType">文件类型</param>
        /// <param name="IsRecursive">是否递归获取子文件夹下文件， 默认为True</param>
        /// <returns></returns>
        public static List<string> GetAllFileFullName(string sPath, bool IsRecursive = true)
        {
            List<string> ltFiles = new List<string>();

            FolderHelper oFolderOperation = new FolderHelper(sPath);
            oFolderOperation.GetAllFiles(IsRecursive);
            for (int i = 0; i < oFolderOperation.listAllFiles.Count; i++)
            {
                if (CvUtils.IsImageType(oFolderOperation.listAllFiles[i]))
                    ltFiles.Add(oFolderOperation.listAllFiles[i]);
            }
            return ltFiles;
        }

        #endregion

        #region 》获取文件夹下所有文件夹、子文件夹
        /// <summary>
        /// 获取文件夹下所有文件夹、子文件夹
        /// </summary>
        /// <param name="sPath">文件夹路径</param>
        /// <returns>文件夹及子文件夹下所有文件</returns>
        public static List<string> GetAllFolder(string sPath, bool IsRecursive = true)
        {
            FolderHelper oFolderOperation = new FolderHelper(sPath);
            oFolderOperation.GetAllFiles(IsRecursive);
            return oFolderOperation.listAllDirs;
        }
        #endregion

     

        #region 》Folder Operation

        /// <summary>
        /// 当前文件夹
        /// </summary>
        private string FolderPath;

        public FolderHelper(string sFolderPath)
        {
            this.FolderPath = sFolderPath;
        }

        /// <summary>
        /// 文件夹、子文件夹下所有文件列表
        /// </summary>
        private List<string> listAllFiles = new List<string>();
        /// <summary>
        /// 文件夹、文件夹下所有子文件夹列表
        /// </summary>
        private List<string> listAllDirs = new List<string>();

        /// <summary>
        /// 遍历获取所有文件、所有文件夹(包含子文件夹)列表
        /// </summary>
        public void GetAllFiles(bool IsRecursive = true)
        {
            if (Directory.Exists(this.FolderPath))
            {
                this.GetAllChildDir(this.FolderPath, IsRecursive); //获取所有子文件夹
                if (IsRecursive)
                    this.listAllDirs.Add(this.FolderPath); //添加跟节点文件夹
            }
        }

        /// <summary>
        /// 遍历文件夹下所有子文件夹
        /// </summary>
        /// <param name="fatherPath">文件夹路径</param>
        private void GetAllChildDir(string fatherPath, bool IsRecursive)
        {
            DirectoryInfo dir = new DirectoryInfo(fatherPath);
            FileInfo[] fis = dir.GetFiles();
            if (fis.Length > 0)
            {
                for (int j = 0; j < fis.Length; j++)
                    this.listAllFiles.Add(fis[j].FullName);
            }

            try
            {
                DirectoryInfo[] dirSons = dir.GetDirectories();
                for (int i = 0; i < dirSons.Length; i++)
                {
                    listAllDirs.Add(dirSons[i].FullName);
                    if (IsRecursive)
                        GetAllChildDir(dirSons[i].FullName, IsRecursive); //递归
                }
            }
            catch (Exception)
            { }
        }

        #endregion
    }
}
