using LibGit2Sharp;
using System;

namespace Githelper.Helpers.Git
{
    public static class GitActions
    {
        public static void ChangeBranch()
        {
            string[] Branches = GetBranches();
            Console.Clear();
            Console.WriteLine("=======================Select Branch to Change To=======================\r\n");

            for (int i = 1; i < Branches.Length; i++)
            {
                if (i % 2 == 0)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"{i + 1}: {Branches[i]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{i + 1}: {Branches[i]}");
                }
            }

            int.TryParse(Console.ReadLine(), out int Input);

            using Repository repo = new Repository(GlobalSettings.GitPath);
            Remote remote = repo.Network.Remotes["origin"];
            try
            {
                var branch = repo.CreateBranch(Branches[Input - 1].Substring(Branches[Input - 1].LastIndexOf('/') + 1), Branches[Input - 1]);
                Commands.Checkout(repo, branch);
                repo.Branches.Update(branch, b => b.UpstreamBranch = branch.CanonicalName);
            }
            catch (Exception e)
            {
                var branch = repo.Branches[Branches[Input - 1]];
                repo.Branches.Update(branch, b => b.UpstreamBranch = branch.CanonicalName);
                Commands.Checkout(repo, branch);
            }
        }

        private static string[] GetBranches()
        {
            string branches = "";
            using (var repo = new Repository(GlobalSettings.GitPath))
            {
                if (repo.Info.CurrentOperation != CurrentOperation.None)
                {
                    throw new ApplicationException("Invalid Git state please have a clean working tree");
                }

                foreach (Branch br in repo.Branches)
                {
                    branches += "|" + br.CanonicalName;
                }
            }
            return branches.Split('|');
        }
    }
}