using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Reskrimsus.BusinessEntity;
using Reskrimsus.BusinessRule;
using System.Web.UI.HtmlControls;


namespace Reskrimsus.Website.Gallery
{
    public partial class Video : Base
    {
        WebsiteContentBL _websiteContentBL = new WebsiteContentBL();
        CompanyConfigBL _companyConfigBL = new CompanyConfigBL();
        IEnumerable<WsGalleryVideo> _wsGalleryVideoEnumerable = new List<WsGalleryVideo>();
        private int _maxSizeRow = 2;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.SetDefaultLoad();
            if (!this.Page.IsPostBack)
            {
                this.ShowData();
            }
        }

        protected void SetDefaultLoad()
        {
        }

        protected void ShowData()
        {
            //this._page = _prmCurrentPage;
            //this.URLFileHiddenField.Value = this._companyConfigBL.GetSinglecompanyconfiguration("URLFile").SetValue;
            //List<WsGalleryVideo> _listWsGalleryVideo = this._websiteContentBL.GetListWsGalleryVideoWithPage(_page, _maxSizeRow);
            //this.ListRepeater.DataSource = _listWsGalleryVideo;
            //this.ListRepeater.DataBind();
            this.URLFileHiddenField.Value = this._companyConfigBL.GetSinglecompanyconfiguration("URLFile").SetValue;
            _wsGalleryVideoEnumerable = this._websiteContentBL.GetListWsGalleryVideo();
            List<String> _listYear = this._websiteContentBL.GetListWsGalleryVideoYear();
            this.ListRepeater.DataSource = _listYear;
            this.ListRepeater.DataBind();
        }

        protected void ListRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                String _year = (String)e.Item.DataItem;

                Literal _yearLiteral = (Literal)e.Item.FindControl("YearLiteral");
                _yearLiteral.Text = _year;

                Repeater _listDetailRepeater = (Repeater)e.Item.FindControl("ListDetailRepeater");
                List<WsGalleryVideo> _listWsGalleryEvent = _wsGalleryVideoEnumerable.Where(x => Convert.ToDateTime(x.VideoPeriod).Year == Convert.ToInt32(_year)).ToList();
                _listDetailRepeater.DataSource = _listWsGalleryEvent;
                _listDetailRepeater.DataBind();

                HtmlTableCell _yearCell = (HtmlTableCell)e.Item.FindControl("YearTd");
                _yearCell.ColSpan = _listWsGalleryEvent.Count;

                //HtmlTableRow _tableRow = (HtmlTableRow)e.Item.FindControl("RepeaterItemTemplate");
                //_tableRow.Attributes.Add("OnMouseOver", "this.style.backgroundColor='" + this._rowColorHover + "';");
                //if (e.Item.ItemType == ListItemType.Item)
                //{
                //    _tableRow.Attributes.Add("style", "background-color:" + this._rowColor);
                //    _tableRow.Attributes.Add("OnMouseOut", "this.style.backgroundColor='" + this._rowColor + "';");
                //}
                //if (e.Item.ItemType == ListItemType.AlternatingItem)
                //{
                //    _tableRow.Attributes.Add("style", "background-color:" + this._rowColorAlternate);
                //    _tableRow.Attributes.Add("OnMouseOut", "this.style.backgroundColor='" + this._rowColorAlternate + "';");
                //}
            }
        }

        protected void ListDetailRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                WsGalleryVideo _temp = (WsGalleryVideo)e.Item.DataItem;

                Literal _videoLiteral = (Literal)e.Item.FindControl("VideoLiteral");
                Literal _videoNameLiteral = (Literal)e.Item.FindControl("VideoNameLiteral");

                //_videoLiteral.Text = " <video width=\"640\" height=\"352\" controls=\"controls\" controls autoplay> ";
                _videoLiteral.Text = " <video width=\"320\" height=\"176\" controls=\"controls\"> ";
                _videoLiteral.Text += "<source src=\"" + this.URLFileHiddenField.Value+_temp.VideoFile + "\" type=\"video/mp4\"/> ";
                _videoLiteral.Text += "browser anda tidak mendukung video </video>";

                _videoNameLiteral.Text = _temp.VideoTitle;
            }
        }
    }
}
