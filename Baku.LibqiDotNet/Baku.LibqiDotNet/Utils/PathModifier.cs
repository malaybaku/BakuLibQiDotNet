using System;
using System.IO;
using System.Reflection;

namespace Baku.LibqiDotNet.Path
{
    /// <summary>アンマネージライブラリの参照パスを追加するためのユーティリティ処理を提供します。</summary>
    public static class PathModifier
    {
        /// <summary>
        /// 指定したディレクトリを起点とし、環境変数のPATHをプロセス内限定で変更することで
        /// アンマネージライブラリの参照パスを追加します。
        /// </summary>
        /// <param name="path">指定したディレクトリからの相対パス。親ディレクトリ側を指さないことが推奨されます。</param>
        /// <param name="modifyMode">起点となるディレクトリの種類</param>
        public static void AddEnvironmentPath(string path, PathModifyMode modifyMode)
        {
            string baseDir =
                (modifyMode == PathModifyMode.RelativeToEntryAssembly) ?
                    System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) :
                (modifyMode == PathModifyMode.RelativeToExecutingAssembly) ?
                    System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) :
                    Environment.CurrentDirectory;

            string absDir = System.IO.Path.Combine(baseDir, path);
            if (!Directory.Exists(absDir)) throw new DirectoryNotFoundException(
                $"Directory to search was not found, this program expects the directory {absDir} to exists"
                );

            AddEnvironmentPath(absDir);
        }

        private static void AddEnvironmentPath(string addedPath)
        {
            string currentPath = Environment.GetEnvironmentVariable("PATH") ?? "";
            string newPath = currentPath + System.IO.Path.PathSeparator.ToString() + addedPath;

            Environment.SetEnvironmentVariable("PATH", newPath);
        }
    }

    /// <summary>
    /// <see cref="PathModifier.AddEnvironmentPath(string)"/>関数において
    /// 指定するディレクトリの起点の種類を表します。
    /// </summary>
    public enum PathModifyMode
    {
        /// <summary>プロセス全体を実行しているexeファイルのディレクトリを起点とします。</summary>
        RelativeToEntryAssembly,
        /// <summary>このライブラリを含むアセンブリファイルが存在するディレクトリを起点とします。</summary>
        RelativeToExecutingAssembly,
        /// <summary>作業ディレクトリを起点とします。</summary>
        RelativeToWorkingDirectory,
    }
}
