using NUnit.Framework;
namespace autotests.Test
{
    public class BATest : BaseTest
    {
        [Test]
        public static void TestBA()
        {
            testPage.NavigateToPage();
            testPage.SearchForItemByText();
            testPage.CheckItemText();
            testPage.SelectMugOptions();
            testPage.CartOptions();
            testPage.FillingPersonalInfo();
        }
    }
}
