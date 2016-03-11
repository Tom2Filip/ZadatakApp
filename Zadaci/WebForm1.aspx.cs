using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zadaci.Models;
using Elmah;
using System.Data.Entity.Core;
using System.Data;
using System.Threading;

namespace Zadaci
{
    public partial class WebForm1 : BaseClass //System.Web.UI.Page
    {

        protected void btn_Click2(object sender, EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            switch (btn.ID)
            {
                case ("imagebuttonEnglish"):
                    Session["culture2"] = "en-GB";
                    Server.Transfer(Request.Url.PathAndQuery, false);
                    break;

                case ("imagebuttonHrvatski"):
                    Session["culture2"] = "hr-HR";
                    Server.Transfer(Request.Url.PathAndQuery, false);
                    break;                                    
            }
        }
        

        protected void Page_Load(object sender, EventArgs e)
        {
                              
            if (!IsPostBack)
            {
                BindGridViewZadaci();
                btnZavrsi.Enabled = false;
                LoadTimeDropDownList();
            }
        }

        private void BindGridViewZadaci()
        {
            try
            {
                ZadaciDBEntities context = new ZadaciDBEntities();
                var query = context.Zadaci;
                zadaciGridView.DataSource = query.ToList();
                zadaciGridView.DataBind();
            }
            catch (InvalidOperationException)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "greskaPriDohvatuPodataka");
            }
            catch (MetadataException)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "greskaPriDohvatuPodataka");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "greskaPriDohvatuPodataka");
            }
            catch (EntityException)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "greskaPriDohvatuPodataka");
            }
            catch (DataException)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "greskaPriDohvatuPodataka");
            }
            catch (Exception)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "Greska");
            }
        }

        private void LoadTimeDropDownList()
        {
            // find DropDownList control inside DetailsView
            DropDownList ddlHours = (DropDownList)DodajZadatakDetailsView.FindControl("ddlHours");
            DropDownList ddlMinutes = (DropDownList)DodajZadatakDetailsView.FindControl("ddlMinutes");
            // Time DropDownList
            for (int index = 0; index < 24; index++)
            {
                ddlHours.Items.Add(index.ToString("00"));
            }
            for (int index = 0; index < 60; index++)
            {

                ddlMinutes.Items.Add(index.ToString("00"));
            }
        }


        protected void zadaciGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnZavrsi.Enabled = true;
                int zadatakID = (int)zadaciGridView.SelectedDataKey["Id"];
                ZadaciDBEntities context = new ZadaciDBEntities();
                var query = context.Zadaci.Where(z => z.Id == zadatakID).ToList();
                DodajZadatakDetailsView.ChangeMode(DetailsViewMode.Edit);
                DodajZadatakDetailsView.DataSource = query;
                DodajZadatakDetailsView.DataBind();
                LoadTimeDropDownList();

                DateTime datum = new DateTime();
                datum = query.FirstOrDefault().Start;

                // set Date in Calendar
                Calendar calendarStart = (Calendar)DodajZadatakDetailsView.FindControl("startDateCalendar");
                calendarStart.SelectedDate = datum.Date;
                calendarStart.VisibleDate = datum.Date;

                // set time in DropDownList
                DropDownList ddlHours = (DropDownList)DodajZadatakDetailsView.FindControl("ddlHours");
                DropDownList ddlMinutes = (DropDownList)DodajZadatakDetailsView.FindControl("ddlMinutes");
                ddlHours.Text = datum.Hour.ToString("00");
                ddlMinutes.Text = datum.Minute.ToString("00");
            }
            catch (InvalidOperationException)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "greskaPriDohvatuPodataka");
            }
            catch (MetadataException)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "greskaPriDohvatuPodataka");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "greskaPriDohvatuPodataka");
            }
            catch (EntityException)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "greskaPriDohvatuPodataka");
            }
            catch (DataException)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "greskaPriDohvatuPodataka");
            }
            catch (Exception)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "Greska");
            }
            
        }

        protected void btnZavrsi_Click(object sender, EventArgs e)
        {
            int zadatakID = (int)zadaciGridView.SelectedDataKey.Value;

            try
            {
                ZadaciDBEntities context = new ZadaciDBEntities();
                var query = context.Zadaci.Where(z => z.Id == zadatakID).FirstOrDefault();

                if (query.Status == true)
                {
                   // lblErrorMessage.Text = "Zadatak je već završen.";                  
                    lblErrorMessage.Text = GetGlobalResourceObject("Resource", "zadatakZavrsenMessage").ToString();
                }
                else
                {
                    query.Status = true;
                    query.Kraj = DateTime.Now;
                    context.SaveChanges();
                    Response.Redirect("~/WebForm1.aspx");
                }
            }
            catch (InvalidOperationException)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "greskaPriDohvatuPodataka");
            }
            catch (MetadataException)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "greskaPriDohvatuPodataka");

            }
            catch (System.Data.SqlClient.SqlException)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "greskaPriDohvatuPodataka");
            }
            catch (EntityException)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "greskaPriDohvatuPodataka");
            }
            catch (DataException)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "greskaPriDohvatuPodataka");
            }
            catch (Exception)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "Greska");
            }
        }


        protected void DodajZadatakDetailsView_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            string naslov = e.Values["Naslov"].ToString().Trim();

            try
            {
                if (ValidationZadatak(naslov))
                {
                    throw new NaslovValidationException((string)GetGlobalResourceObject("Resource", "greskaPostojiZadatak") + " " + naslov);
                }
                else
                {
                    DropDownList ddlHours = (DropDownList)DodajZadatakDetailsView.FindControl("ddlHours");
                    DropDownList ddlMinutes = (DropDownList)DodajZadatakDetailsView.FindControl("ddlMinutes");
                    double hours = Convert.ToDouble(ddlHours.SelectedValue);
                    double minutes = Convert.ToDouble(ddlMinutes.SelectedValue);
                    DateTime datumStart = Convert.ToDateTime(e.Values["Start"]).AddHours(hours).AddMinutes(minutes);

                    string opis = "";

                    if (!String.IsNullOrEmpty((string)e.Values["Opis"]))
                    {
                        opis = e.Values["Opis"].ToString();
                    }

                    ZadaciDBEntities context = new ZadaciDBEntities();
                    context.InsertZadatak(datumStart, naslov, opis, false, null);

                    Response.Redirect("~/WebForm1.aspx");
                }
            }
            catch (NaslovValidationException valEx)
            {
                ErrorSignal.FromCurrentContext().Raise(valEx);
                lblErrorMessage.Text = valEx.Message;
            }
            catch (InvalidOperationException)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "greskaPriUnosuPodataka");
            }
            catch (MetadataException)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "greskaPriUnosuPodataka");

            }
            catch (System.Data.SqlClient.SqlException)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "greskaPriUnosuPodataka");
            }
            catch (EntityException)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "greskaPriUnosuPodataka");
            }
            catch (DataException)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "greskaPriUnosuPodataka");
            }
            catch (Exception)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "Greska");
            }
        }

        protected void DodajZadatakDetailsView_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            if (e.CancelingEdit)
            {
                Response.Redirect("~/WebForm1.aspx");
            }
        }


        protected void calendarImage_Click(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.Calendar cal = (System.Web.UI.WebControls.Calendar)DodajZadatakDetailsView.FindControl("startDateCalendar");
            cal.Visible = true;
        }

        protected void startDateCalendar_SelectionChanged(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.Calendar calendar = (System.Web.UI.WebControls.Calendar)DodajZadatakDetailsView.FindControl("startDateCalendar");
            TextBox startDateTextBox = (TextBox)DodajZadatakDetailsView.FindControl("startDateTextBox");
            startDateTextBox.Text = calendar.SelectedDate.ToShortDateString();
            calendar.Visible = false;
        }

        protected void zadaciGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int zadatakId = (int)e.Keys["Id"];
            try
            {
                ZadaciDBEntities context = new ZadaciDBEntities();
                Zadatak zadatakZaObrisati = new Zadatak();
                zadatakZaObrisati = context.Zadaci.Where(z => z.Id == zadatakId).FirstOrDefault();
                context.Zadaci.Remove(zadatakZaObrisati);
                context.SaveChanges();
                Response.Redirect("~/WebForm1.aspx");
            }
            catch (InvalidOperationException)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "greskaPriBrisanjuPodataka");
            }
            catch (MetadataException)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "greskaPriBrisanjuPodataka");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "greskaPriBrisanjuPodataka");
            }
            catch (EntityException)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "greskaPriBrisanjuPodataka");
            }
            catch (DataException)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "greskaPriBrisanjuPodataka");
            }
            catch (Exception)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "Greska");
            }
        }

        // Napraviti validaciju kojom se onemogućava unos dva zapisa istog naslova sa istim statusom, a pri pokušaju takvog unosa informaciju zapisati u sql server log te vratiti pogrešku.
        private bool ValidationZadatak(string Naslov)
        {
            ZadaciDBEntities context = new ZadaciDBEntities();
            var query = context.Zadaci.Where(z => (z.Naslov == Naslov) && (z.Status == false)).ToList();

            if (query.Count > 0)
            {
                /*
                lblErrorMessage.Text = "Nezavršeni zadaci s istim naslovom:";
                foreach (var zad in query)
                {
                    lblErrorMessage.Text += "<br/> " + zad.Id + " " + zad.Naslov;
                }
                */
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidationZadatak(string Naslov, int ID)
        {
            ZadaciDBEntities context = new ZadaciDBEntities();
            var query = context.Zadaci.Where(z => (z.Naslov == Naslov) && (z.Status == false) && (z.Id != ID)).ToList();
            
            if (query.Count > 0)
            {   
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void DodajZadatakDetailsView_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            string naslov = e.NewValues["Naslov"].ToString().Trim();
            
            try
            {
                int zadatakId = (int)zadaciGridView.SelectedDataKey.Value;
                ZadaciDBEntities context1 = new ZadaciDBEntities();
                var zadatak1 = context1.Zadaci.Where(z => z.Id == zadatakId).FirstOrDefault();

                if (zadatak1.Status == false)
                {
                    if (ValidationZadatak(naslov, zadatakId))
                    {
                        throw new NaslovValidationException((string)GetGlobalResourceObject("Resource", "greskaPostojiZadatak") + " " + naslov);
                    }                    
                }
                
                    DropDownList ddlHours = (DropDownList)DodajZadatakDetailsView.FindControl("ddlHours");
                    DropDownList ddlMinutes = (DropDownList)DodajZadatakDetailsView.FindControl("ddlMinutes");
                    double hours = Convert.ToDouble(ddlHours.SelectedValue);
                    double minutes = Convert.ToDouble(ddlMinutes.SelectedValue);
                    DateTime datumStart = Convert.ToDateTime(e.NewValues["Start"]).AddHours(hours).AddMinutes(minutes);

                    string opis = "";

                    if (!String.IsNullOrEmpty((string)e.NewValues["Opis"]))
                    {
                        opis = e.NewValues["Opis"].ToString();
                    }

                    ZadaciDBEntities context = new ZadaciDBEntities();
                    Zadatak zadatakZaUrediti = new Zadatak();
                    zadatakZaUrediti = context.Zadaci.Where(z => z.Id == zadatakId).FirstOrDefault();

                    zadatakZaUrediti.Naslov = e.NewValues["Naslov"].ToString();
                    zadatakZaUrediti.Start = datumStart;
                    zadatakZaUrediti.Opis = opis;

                    context.SaveChanges();
                    Response.Redirect("~/WebForm1.aspx");                
                
            }
            catch (NaslovValidationException valEx)
            {
                ErrorSignal.FromCurrentContext().Raise(valEx);
                lblErrorMessage.Text = valEx.Message;
            }
            catch (InvalidOperationException)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "greskaPriUnosuPodataka");
            }
            catch (MetadataException)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "greskaPriUnosuPodataka");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "greskaPriUnosuPodataka");
            }
            catch (EntityException)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "greskaPriUnosuPodataka");
            }
            catch (DataException)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "greskaPriUnosuPodataka");
            }
            catch (Exception)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "Greska");
            }           
        }

        protected void zadaciGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortDirection sortDirection = SortDirection.Ascending;
            string sortField = string.Empty;

            SortGridview((GridView)sender, e, out sortDirection, out sortField);
            string strSortDirection = sortDirection == SortDirection.Ascending ? "ASC" : "DESC";
            
            BindGridViewZadaci2(sortField, strSortDirection);
        }

        private void BindGridViewZadaci2(string sortField, string SortDirection)
        {
            try
            {
                ZadaciDBEntities context = new ZadaciDBEntities();
                var query = context.Zadaci.ToList();

                // github.com/Tom2Filip/MovieCatalog/blob/master/MovieCatalog/Default.aspx.cs
                if (SortDirection == "ASC")
                {
                    query = query.OrderBy(zad => zad.GetType().GetProperty(sortField).GetValue(zad, null)).ToList();
                }
                else if (SortDirection == "DESC")
                {
                    query = query.OrderByDescending(zad => zad.GetType().GetProperty(sortField).GetValue(zad, null)).ToList();
                }

                zadaciGridView.DataSource = query.ToList();
                zadaciGridView.DataBind();
                zadaciGridView.SelectedIndex = -1;
                DodajZadatakDetailsView.ChangeMode(DetailsViewMode.Insert);
            }
            catch (InvalidOperationException)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "greskaPriDohvatuPodataka");
            }
            catch (MetadataException)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "greskaPriDohvatuPodataka");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "greskaPriDohvatuPodataka");
            }
            catch (EntityException)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "greskaPriDohvatuPodataka");
            }
            catch (DataException)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "greskaPriDohvatuPodataka");
            }
            catch (Exception)
            {
                lblErrorMessage.Text = (string)GetGlobalResourceObject("Resource", "Greska");
            }
        }

        private void SortGridview(GridView gridView, GridViewSortEventArgs e, out SortDirection sortDirection, out string sortField)
        {
            sortField = e.SortExpression;
            sortDirection = e.SortDirection;

            if (gridView.Attributes["CurrentSortField"] != null && gridView.Attributes["CurrentSortDirection"] != null)
            {
                if (sortField == gridView.Attributes["CurrentSortField"])
                {
                    if (gridView.Attributes["CurrentSortDirection"] == "ASC")
                    {
                        sortDirection = SortDirection.Descending;
                    }
                    else
                    {
                        sortDirection = SortDirection.Ascending;
                    }
                }

                gridView.Attributes["CurrentSortField"] = sortField;
                gridView.Attributes["CurrentSortDirection"] = (sortDirection == SortDirection.Ascending ? "ASC" : "DESC");
            }           
        }

        protected void zadaciGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string sortField = "";
            string strSortDirection = "";

            sortField = zadaciGridView.Attributes["CurrentSortField"];
            strSortDirection = zadaciGridView.Attributes["CurrentSortDirection"];

            zadaciGridView.PageIndex = e.NewPageIndex;
            BindGridViewZadaci2(sortField, strSortDirection);
        }
                
    }
}