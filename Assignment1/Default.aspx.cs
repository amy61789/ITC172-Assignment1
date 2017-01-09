using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string[] tipPercent = { "Ten Percent", "Fifteen Percent", "Twenty Percent", "Other" };
            TipPercentsRBL.DataSource = tipPercent;
            TipPercentsRBL.DataBind();
        }
    }

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        GetInfo();
    }

    protected void GetInfo()
    {
        Tip tip = new Tip();

        //assigning value 
        tip.MealAmount = double.Parse(MealTextBox.Text);

        if (OtherTextBox.Text == "")
        {
            tip.TipPercent = 0;
            foreach (ListItem item in TipPercentsRBL.Items)
            {
                if (item.Selected == true)
                {
                    if (item.Text.Equals("Ten Percent"))
                    {
                        tip.TipPercent = .1;
                    }
                    else if (item.Text.Equals("Fifteen Percent"))
                    {
                        tip.TipPercent = .15;
                    }
                    else if (item.Text.Equals("Twenty Percent"))
                    {
                        tip.TipPercent = .2;
                    }
                }
            }
        }
        else
        {
            tip.TipPercent = double.Parse(OtherTextBox.Text);
        }

        ResultLabel.Text = "<br/>Meal Amount: " + tip.MealAmount.ToString("$#,##0.00") + "<br/>" +
            "Tip: " + tip.CalculateTip().ToString("$#,##0.00") + "<br/>" +
            "Tax: " + tip.CalculateTax().ToString("$#,##0.00") + "<br/>" +
            "Total: " + tip.CalculateTotal().ToString("$#,##0.00");
    }
}