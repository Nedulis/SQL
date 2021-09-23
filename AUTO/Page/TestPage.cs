using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
namespace autotests.Page
{
    public class TestPage : BasePage
    {
        private const string AddressUrl = "https://demo.prestashop.com/";
        private IWebElement optionsField => Driver.FindElement(By.CssSelector("#main > div.row.product-container > div:nth-child(2) > div.product-information > section > div > form > ul > li > textarea"));
        private IWebElement searchField => Driver.FindElement(By.CssSelector("#search_widget > form > input.ui-autocomplete-input"));
        private IWebElement shoppingCartText => Driver.FindElement(By.CssSelector("#myModalLabel"));
        private IWebElement checkOutButton => Driver.FindElement(By.CssSelector("#blockcart-modal > div > div > div.modal-body > div > div.col-md-7 > div > div > a"));
        private IWebElement cartCheckOutButton => Driver.FindElement(By.CssSelector("#main > div > div.cart-grid-right.col-xs-12.col-lg-4 > div.card.cart-summary > div.checkout.cart-detailed-actions.card-block > div > a"));
        private IWebElement optionSelectButton => Driver.FindElement(By.CssSelector("#main > div.row.product-container > div:nth-child(2) > div.product-information > section > div > form > div > button"));
        private IWebElement searchButton => Driver.FindElement(By.CssSelector("#search_widget > form > button > i"));
        private IWebElement addToCartButton => Driver.FindElement(By.CssSelector("#add-to-cart-or-refresh > div.product-add-to-cart > div > div.add > button"));
        private IWebElement genderButton => Driver.FindElement(By.CssSelector("#customer-form > section > div:nth-child(1) > div.col-md-6.form-control-valign > label:nth-child(1) > span > input[type=radio]"));
        private IWebElement itemText => Driver.FindElement(By.CssSelector("#js-product-list > div.products.row > div:nth-child(1) > article > div > div.product-description > h2 > a"));
        public TestPage(IWebDriver webdriver) : base(webdriver) { }
        public void NavigateToPage()
        {
            if (Driver.Url != AddressUrl)
            {
                Driver.Url = AddressUrl;
            }
        }
        public void SearchForItemByText()
        {
            Driver.SwitchTo().Frame(Driver.FindElement(By.CssSelector("#framelive")));
            searchField.Clear();
            searchField.Click();
            searchField.SendKeys("mug");
            searchButton.Click();
        }
        public void CheckItemText()
        {
            itemText.Text.Contains("mug");
            itemText.Click();
        }
        public void SelectMugOptions()
        {
            optionsField.Clear();
            optionsField.Click();
            optionsField.SendKeys("123");
            optionSelectButton.Click();
            addToCartButton.Click();
            Thread.Sleep(1000); // 50/50 work
        }
       public void ConfirmItemAdded()
        {
            shoppingCartText.Text.Contains("Product successfully added to your shopping cart");
            Assert.IsTrue(shoppingCartText.Text.Contains("Product successfully added to your shopping cart"), "No");
        }
        public void CartOptions()
        {
            checkOutButton.Click();
            cartCheckOutButton.Click();
        }
        public void FillingPersonalInfo()
        {
            genderButton.Click();
            Driver.FindElement(By.CssSelector("#customer-form > section > div:nth-child(2) > div.col-md-6 > input")).SendKeys("Nedas");
            Driver.FindElement(By.CssSelector("#customer-form > section > div:nth-child(3) > div.col-md-6 > input")).SendKeys("Testing");
            Driver.FindElement(By.CssSelector("#customer-form > section > div:nth-child(4) > div.col-md-6 > input")).SendKeys("tesmngg@gmail.com");
            Driver.FindElement(By.CssSelector("#customer-form > section > div:nth-child(6) > div.col-md-6 > div > input")).SendKeys("Test1793");
            Driver.FindElement(By.CssSelector("#customer-form > section > div:nth-child(7) > div.col-md-6 > input")).SendKeys("05/31/1970");
            Driver.FindElement(By.CssSelector("#customer-form > section > div:nth-child(11) > div.col-md-6 > span > label > input[type=checkbox]")).Click();
            Driver.FindElement(By.CssSelector("#customer-form > section > div:nth-child(9) > div.col-md-6 > span > label > input[type=checkbox]")).Click();
            Driver.FindElement(By.CssSelector("#customer-form > footer > button")).Click();
            Driver.FindElement(By.CssSelector("#delivery-address > div > section > div:nth-child(8) > div.col-md-6 > input")).SendKeys("Greituoliu g. 29-1");
            Driver.FindElement(By.CssSelector("#delivery-address > div > section > div:nth-child(10) > div.col-md-6 > input")).SendKeys("07181");
            Driver.FindElement(By.CssSelector("#delivery-address > div > section > div:nth-child(11) > div.col-md-6 > input")).SendKeys("Vilnius");
            Driver.FindElement(By.CssSelector("#delivery-address > div > footer > button")).Click();
            Driver.FindElement(By.CssSelector("#js-delivery > button")).Click();
            Driver.FindElement(By.CssSelector("#payment-option-2")).Click();
            Driver.FindElement(By.Id("conditions_to_approve[terms-and-conditions]")).Click();
            Driver.FindElement(By.CssSelector("#payment-confirmation > div.ps-shown-by-js > button")).Click();
            Thread.Sleep(5000);
            Assert.IsTrue(Driver.FindElement(By.CssSelector("#content-hook_order_confirmation > div > div > div > h3")).Text.Contains("YOUR ORDER IS CONFIRMED"));

        }
    }
}
