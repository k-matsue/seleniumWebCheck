using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium.Chrome;

namespace SeleniumWebCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            // ChromeOptionsオブジェクトを生成
            var options = new ChromeOptions();

            // --headlessを追加
            options.AddArgument("--headless");
            
            // ChromeOptions付きでChromeDriverオブジェクトを生成
            var chrome = new ChromeDriver(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), options);
            
            // URLに移動
            chrome.Url = @"https://scout.nezas.net/auth/login";
            
            // タイトルを表示
            Console.WriteLine(chrome.Title);

            // ログインID(メールアドレス)入力
            var elementLoginId = chrome.FindElement(OpenQA.Selenium.By.Name("email"));
            elementLoginId.SendKeys("testnezas+support02@e2info.com");

            // パスワード入力
            var elementPassword = chrome.FindElement(OpenQA.Selenium.By.Name("password"));
            elementPassword.SendKeys("qX4CermARKQv");

            // ログインボタンをクリック
            var elementLoginButton = chrome.FindElement(OpenQA.Selenium.By.CssSelector(".btn"));
            elementLoginButton.Click();

            // マイページ画面に遷移したことを確認
            var elementLoginUser = chrome.FindElement(OpenQA.Selenium.By.ClassName("active")).Text;
            Console.WriteLine(elementLoginUser);


            // すぐ終了しないよう、キーが押されるまで待機
            Console.ReadKey();
            
            // ブラウザを閉じる
            chrome.Quit();
        }
    }
}
