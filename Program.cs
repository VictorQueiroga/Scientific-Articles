using System;

namespace ScientificArticles
{
    class Program
    {
        static ArticleRepository Repository = new ArticleRepository();
        static void Main(string[] args)
        {
            string UserOption = Menu();

            while (UserOption.ToUpper() != "X") {
                switch (UserOption) {
                    case "1":
                        ListArticles();
                        break;
                    case "2":
                        InsertArticle();
                        break;
                    case "3":
                        UpdateArticle();
                        break;
                    case "4":
                        DeleteArticle();
                        break;
                    case "5":
                        ShowArticle();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                UserOption = Menu();
            }
            Console.WriteLine("Thank you for using our services!");
            Console.ReadLine();
        }
        private static void ListArticles() {
            Console.WriteLine("List all articles");
            int i = 0;
            var list = Repository.List();

            if (list.Count == 0) {
                Console.WriteLine("No articles found");
                return;
            }

            foreach (var article in list) {
                bool Deleted = article.ReturnDeleted();
                if (!Deleted) {
                    Console.WriteLine("#ID {0}: - {1}", article.ReturnId(), article.ReturnTitle());
                    i++;
                }
            }
            if (i == 0) {
                Console.WriteLine("No articles found");
            }
        }

        private static void InsertArticle() {
            Console.WriteLine("Insert new article");

            foreach (int subject in Enum.GetValues(typeof(Subject))) {
                Console.WriteLine("{0}-{1}", subject, Enum.GetName(typeof(Subject), subject));
            }
            Console.WriteLine("Enter the subject option: ");
            int InputSubject = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the title of the article: ");
            string ArticleTitle = Console.ReadLine();

            Console.WriteLine("Enter the description of the article: ");
            string ArticleDescription = Console.ReadLine();

            Console.WriteLine("Enter the magazine name where the article came from: ");
            string ArticleMagazine = Console.ReadLine();

            Console.WriteLine("Enter the year of publication: ");
            int ArticleYear = int.Parse(Console.ReadLine());

            Article NewArticle = new Article(Id: Repository.NextId(),
                                             subject: (Subject)InputSubject,
                                             Title: ArticleTitle,
                                             Description: ArticleDescription,
                                             Magazine: ArticleMagazine,
                                             Year: ArticleYear);
            Repository.Insert(NewArticle);
        }

        private static void UpdateArticle() {
            Console.WriteLine("Enter the id of the article: ");
            int NewId = int.Parse(Console.ReadLine());

            foreach (int subject in Enum.GetValues(typeof(Subject)))
            {
                Console.WriteLine("{0}-{1}", subject, Enum.GetName(typeof(Subject), subject));
            }
            Console.WriteLine("Enter the subject option: ");
            int InputSubject = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the title of the article: ");
            string ArticleTitle = Console.ReadLine();

            Console.WriteLine("Enter the description of the article: ");
            string ArticleDescription = Console.ReadLine();

            Console.WriteLine("Enter the magazine name where the article came from: ");
            string ArticleMagazine = Console.ReadLine();

            Console.WriteLine("Enter the year of publication: ");
            int ArticleYear = int.Parse(Console.ReadLine());

            Article NewArticle = new Article(Id: NewId,
                                            subject: (Subject)InputSubject,
                                            Title: ArticleTitle,
                                            Description: ArticleDescription,
                                            Magazine: ArticleMagazine,
                                            Year: ArticleYear);
            Repository.Update(NewId, NewArticle);
        }

        private static void DeleteArticle() {
            
            Console.WriteLine("Enter the id of the article: ");
            int ArticleId = int.Parse(Console.ReadLine());

            char Confirm;
            do
            {
                Console.WriteLine("Are you sure you wanna delete the article {0}?", ArticleId);
                Console.WriteLine();
                Console.WriteLine("Enter Y for yes and N for no");
                Confirm = char.Parse(Console.ReadLine().ToUpper());
            } while (Confirm != 'Y' & Confirm != 'N');

            if (Confirm == 'Y') {
                Repository.Delete(ArticleId);
            }

            
        }

        private static void ShowArticle() {
            Console.WriteLine("Enter the id of the article: ");
            int ArticleId = int.Parse(Console.ReadLine());

            var article = Repository.ReturnById(ArticleId);
            Console.WriteLine(article);
        }

        private static string Menu() {
            Console.WriteLine();
            Console.WriteLine("Welcome to Scientific articles!");
            Console.WriteLine("Choose your action: ");

            Console.WriteLine("1- List all articles");
            Console.WriteLine("2- Insert new article");
            Console.WriteLine("3- Update article");
            Console.WriteLine("4- Delete article");
            Console.WriteLine("5- Show article");
            Console.WriteLine("C- Clear screen");
            Console.WriteLine("X- Exit");
            Console.WriteLine();

            string Option = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return Option;
        }
    }
}
