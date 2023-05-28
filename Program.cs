using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SendEmail.Pages;

namespace SendEmail;

internal class Program
{
    static void Main(string[] args)
    {
        var driver = new ChromeDriver();
        IndexPage indexPage = new IndexPage(driver);
        //1.Выполните логин в почтовый сервис с использованием пароля и имени для первого пользователя.
        var loginPage1 = indexPage.SwitchToLoginPage();
        var mailPage1 = loginPage1.InputUserData(1);
        //2. Создать письмо с произвольным телом и заголовком
        mailPage1.SendLetter();
        var indexPage2 = mailPage1.Logout();
        var loginPage2 = indexPage2.SwitchToLoginPage();

        var mailPage2 = loginPage2.InputUserData(2);
        mailPage2.SendLetter();
        mailPage2.Logout();


        //3. Отправить письмо на адрес второго зарегистрированного пользователя
        //4. Выполнить выход из учетной записи первого пользователя
        //5. Выполнить логин в почтовый сервис с использованием пароля и имени для второго пользователя.
        //6. Выполнить логин в почтовый сервис с использованием пароля и имени для второго пользователя.
        //7. Проверить что письмо с заданным на шаге 2 телом и заголовком получено. Если письмо еще не получено- выполнить ожидание, не более 10 минут.
        //8. Ответить на письмо путем нажатия на кнопку Reply. Текст ответа произвольный
        //9. Выполнить выход с учетной записи второго пользователя, выполнить вход с учетной записью первого пользователя и проверить что получен ответ с заданным текстом.
        indexPage2.Uninitialize();
    }
}