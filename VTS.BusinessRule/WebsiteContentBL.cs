using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VTS.BusinessEntity;
using System.Collections;
using System.Data.Linq.SqlClient;

namespace VTS.BusinessRule
{
    public sealed class WebsiteContentBL : Base
    {
        public WebsiteContentBL()
        {
        }
        ~WebsiteContentBL()
        {
        }

        #region WsBanner

        public List<WsBanner> GetListWsBanner()
        {
            List<WsBanner> _result = new List<WsBanner>();

            try
            {
                var _query = (
                    from _WsBanner in this.db.WsBanners
                    orderby _WsBanner.BannerId descending
                    select _WsBanner
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public List<WsBanner> GetListWsBannerActive()
        {
            List<WsBanner> _result = new List<WsBanner>();

            try
            {
                var _query = (
                    from _WsBanner in this.db.WsBanners
                    orderby _WsBanner.BannerId descending
                    where _WsBanner.FgActive == 'Y'
                    select _WsBanner
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public List<WsBanner> GetListWsBanner(String _prmName)
        {
            List<WsBanner> _result = new List<WsBanner>();
            String _pattern = "%" + _prmName + "%";
            try
            {
                var _query = (
                                from _MsPenyidikHd in this.db.WsBanners
                                orderby _MsPenyidikHd.BannerId ascending
                                where _MsPenyidikHd.FgActive == 'Y' &&
                                (SqlMethods.Like(_MsPenyidikHd.BannerName.Trim().ToLower(), _pattern.ToLower()))
                                select _MsPenyidikHd
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public WsBanner GetSingleMsPenyidikHdById(Int32 _prmCode)
        {
            WsBanner _result = null;

            try
            {
                _result = this.db.WsBanners.FirstOrDefault(_temp => _temp.BannerId == _prmCode);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public WsBanner GetSingleWsBanner(String _prmCode)
        {
            WsBanner _result = null;

            try
            {
                _result = this.db.WsBanners.FirstOrDefault(_temp => _temp.BannerId == Convert.ToInt32(_prmCode));
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public WsBanner GetSingleWsBannerLast()
        {
            WsBanner _result = null;
            try
            {
                _result = this.db.WsBanners.OrderByDescending(x => x.BannerId).FirstOrDefault();
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool DeleteMultiWsBanner(String[] _prmCode)
        {
            bool _result = false;

            try
            {
                for (int i = 0; i < _prmCode.Length; i++)
                {
                    WsBanner _table = this.db.WsBanners.FirstOrDefault(_temp => _temp.BannerId.ToString() == _prmCode[i]);
                    this.db.WsBanners.DeleteOnSubmit(_table);
                }
                this.db.SubmitChanges();
                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool AddWsBanner(WsBanner _prmTable)
        {
            bool _result = false;
            try
            {
                this.db.WsBanners.InsertOnSubmit(_prmTable);
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool EditWsBanner(WsBanner _prmTable)
        {
            bool _result = false;

            try
            {
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }
        #endregion

        #region WsGalleryEvent

        public List<WsGalleryEvent> GetListWsGalleryEvent()
        {
            List<WsGalleryEvent> _result = new List<WsGalleryEvent>();

            try
            {
                var _query = (
                    from _WsGalleryEvent in this.db.WsGalleryEvents
                    orderby _WsGalleryEvent.EventId descending
                    where _WsGalleryEvent.FgActive == 'Y'
                    select _WsGalleryEvent
                             );

                foreach (var _row in _query)
                    _result.Add(_row);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public List<WsGalleryEvent> GetListWsGalleryEventAllStatus()
        {
            List<WsGalleryEvent> _result = new List<WsGalleryEvent>();

            try
            {
                var _query = (
                    from _WsGalleryEvent in this.db.WsGalleryEvents
                    orderby _WsGalleryEvent.EventId descending
                    select _WsGalleryEvent
                             );

                foreach (var _row in _query)
                    _result.Add(_row);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }


        public List<WsGalleryEvent> GetListWsGalleryEvent(String _prmName)
        {
            List<WsGalleryEvent> _result = new List<WsGalleryEvent>();
            String _pattern = "%" + _prmName + "%";
            try
            {
                var _query = (
                                from _WsGalleryEvent in this.db.WsGalleryEvents
                                orderby _WsGalleryEvent.EventId ascending
                                where _WsGalleryEvent.FgActive == 'Y' &&
                                (SqlMethods.Like(_WsGalleryEvent.EventTitle.Trim().ToLower(), _pattern.ToLower()))
                                select _WsGalleryEvent
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public WsGalleryEvent GetSingleWsGalleryEvent(Int32 _prmCode)
        {
            WsGalleryEvent _result = null;
            try
            {
                _result = this.db.WsGalleryEvents.FirstOrDefault(_temp => _temp.EventId == _prmCode);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public WsGalleryEvent GetSingleWsGalleryEvent(String _prmCode)
        {
            WsGalleryEvent _result = null;

            try
            {
                _result = this.db.WsGalleryEvents.FirstOrDefault(_temp => _temp.EventId == Convert.ToInt32(_prmCode));
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool DeleteMultiWsGalleryEvent(String[] _prmCode)
        {
            bool _result = false;

            try
            {
                for (int i = 0; i < _prmCode.Length; i++)
                {
                    WsGalleryEvent _table = this.db.WsGalleryEvents.FirstOrDefault(_temp => _temp.EventId.ToString() == _prmCode[i]);
                    this.db.WsGalleryEvents.DeleteOnSubmit(_table);
                }
                this.db.SubmitChanges();
                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool AddWsGalleryEvent(WsGalleryEvent _prmTable)
        {
            bool _result = false;
            try
            {
                this.db.WsGalleryEvents.InsertOnSubmit(_prmTable);
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool EditWsGalleryEvent(WsGalleryEvent _prmTable)
        {
            bool _result = false;

            try
            {
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public List<String> GetListvw_GalleryEvent()
        {
            List<String> _result = new List<String>();

            try
            {
                var _query = (from _vw_GalleryEvent in this.db.vw_GalleryEvents
                              select _vw_GalleryEvent);

                foreach (var _row in _query)
                    _result.Add(_row.Year.ToString());
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        #endregion

        #region WsGalleryVideo

        public List<WsGalleryVideo> GetListWsGalleryVideo()
        {
            List<WsGalleryVideo> _result = new List<WsGalleryVideo>();

            try
            {
                var _query = (
                    from _WsGalleryVideo in this.db.WsGalleryVideos
                    orderby _WsGalleryVideo.VideoId descending
                    where _WsGalleryVideo.FgActive == 'Y'
                    select _WsGalleryVideo
                             );

                foreach (var _row in _query)
                    _result.Add(_row);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public List<WsGalleryVideo> GetListWsGalleryVideoWithPage(int _prmReqPage, int _prmPageSize)
        {
            List<WsGalleryVideo> _result = new List<WsGalleryVideo>();

            try
            {
                var _query = (
                    from _WsGalleryVideo in this.db.WsGalleryVideos
                    orderby _WsGalleryVideo.VideoId descending
                    where _WsGalleryVideo.FgActive == 'Y'
                    select _WsGalleryVideo
                             ).Skip(_prmPageSize * _prmReqPage).Take(_prmPageSize);


                foreach (var _row in _query)
                    _result.Add(_row);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public List<WsGalleryVideo> GetListWsGalleryVideo(String _prmName)
        {
            List<WsGalleryVideo> _result = new List<WsGalleryVideo>();
            String _pattern = "%" + _prmName + "%";
            try
            {
                var _query = (
                                from _WsGalleryVideo in this.db.WsGalleryVideos
                                orderby _WsGalleryVideo.VideoId ascending
                                where _WsGalleryVideo.FgActive == 'Y' &&
                                (SqlMethods.Like(_WsGalleryVideo.VideoTitle.Trim().ToLower(), _pattern.ToLower()))
                                select _WsGalleryVideo
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public WsGalleryVideo GetSingleWsGalleryVideo(Int32 _prmCode)
        {
            WsGalleryVideo _result = null;
            try
            {
                _result = this.db.WsGalleryVideos.FirstOrDefault(_temp => _temp.VideoId == _prmCode);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public WsGalleryVideo GetSingleWsGalleryVideo(String _prmCode)
        {
            WsGalleryVideo _result = null;

            try
            {
                _result = this.db.WsGalleryVideos.FirstOrDefault(_temp => _temp.VideoId == Convert.ToInt32(_prmCode));
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool DeleteMultiWsGalleryVideo(String[] _prmCode)
        {
            bool _result = false;

            try
            {
                for (int i = 0; i < _prmCode.Length; i++)
                {
                    WsGalleryVideo _table = this.db.WsGalleryVideos.FirstOrDefault(_temp => _temp.VideoId.ToString() == _prmCode[i]);
                    this.db.WsGalleryVideos.DeleteOnSubmit(_table);
                }
                this.db.SubmitChanges();
                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool AddWsGalleryVideo(WsGalleryVideo _prmTable)
        {
            bool _result = false;
            try
            {
                this.db.WsGalleryVideos.InsertOnSubmit(_prmTable);
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool EditWsGalleryVideo(WsGalleryVideo _prmTable)
        {
            bool _result = false;

            try
            {
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public List<String> GetListWsGalleryVideoYear()
        {
            List<String> _result = new List<String>();

            try
            {
                var _query = (from _vw_GalleryVideoYears in this.db.vw_GalleryVideoYears
                              select _vw_GalleryVideoYears);

                foreach (var _row in _query)
                    _result.Add(_row.Year.ToString());
            }
            catch (Exception ex)
            {
            }
            return _result;
        }
        #endregion

        #region WsCommunityReport

        public List<WsCommunityReport> GetListWsCommunityReport()
        {
            List<WsCommunityReport> _result = new List<WsCommunityReport>();

            try
            {
                var _query = (
                                from _table in this.db.WsCommunityReports
                                orderby _table.CommunityId ascending
                                where _table.FgActive == "Y"
                                select _table
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public List<WsCommunityReport> GetListWsCommunityReport(String _prmName)
        {
            List<WsCommunityReport> _result = new List<WsCommunityReport>();
            String _pattern = "%" + _prmName + "%";
            try
            {
                var _query = (
                                from _table in this.db.WsCommunityReports
                                orderby _table.CommunityId ascending
                                where _table.FgActive == "Y" &&
                                (SqlMethods.Like(_table.CommunityName.Trim().ToLower(), _pattern.ToLower()))
                                select _table
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public WsCommunityReport GetSingleWsCommunityReport(Int32 _prmCode)
        {
            WsCommunityReport _result = null;

            try
            {
                _result = this.db.WsCommunityReports.FirstOrDefault(_temp => _temp.CommunityId == _prmCode);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool DeleteMultiWsCommunityReport(String[] _prmCode)
        {
            bool _result = false;

            try
            {
                for (int i = 0; i < _prmCode.Length; i++)
                {
                    WsCommunityReport _table = this.db.WsCommunityReports.FirstOrDefault(_temp => _temp.CommunityId.ToString() == _prmCode[i]);
                    this.db.WsCommunityReports.DeleteOnSubmit(_table);
                }
                this.db.SubmitChanges();
                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool AddWsCommunityReport(WsCommunityReport _prmTable)
        {
            bool _result = false;
            try
            {
                this.db.WsCommunityReports.InsertOnSubmit(_prmTable);
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool EditWsCommunityReport(WsCommunityReport _prmTable)
        {
            bool _result = false;

            try
            {
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }
        #endregion

        #region LaporanMasyarakat

        public List<WsLaporanMasyarakat> GetListLaporanMasyarakat()
        {
            List<WsLaporanMasyarakat> _result = new List<WsLaporanMasyarakat>();

            try
            {
                var _query = (
                                from _table in this.db.WsLaporanMasyarakats
                                orderby _table.id descending
                                where _table.FgActive == "Y"
                                select _table
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public List<WsLaporanMasyarakat> GetListWsLaporanMasyarakat()
        {
            List<WsLaporanMasyarakat> _result = new List<WsLaporanMasyarakat>();
            try
            {
                var _query = (
                                from _table in this.db.WsLaporanMasyarakats
                                orderby _table.id descending
                                select _table
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public WsLaporanMasyarakat GetSingleWsLaporanMasyarakat(Int32 _prmCode)
        {
            WsLaporanMasyarakat _result = null;

            try
            {
                _result = this.db.WsLaporanMasyarakats.FirstOrDefault(_temp => _temp.id == _prmCode);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool DeleteMultiWsLaporanMasyarakat(String[] _prmCode)
        {
            bool _result = false;

            try
            {
                for (int i = 0; i < _prmCode.Length; i++)
                {
                    WsLaporanMasyarakat _table = this.db.WsLaporanMasyarakats.FirstOrDefault(_temp => _temp.id.ToString() == _prmCode[i]);
                    this.db.WsLaporanMasyarakats.DeleteOnSubmit(_table);
                }
                this.db.SubmitChanges();
                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        //public bool AddWsCommunityReport(WsCommunityReport _prmTable)
        //{
        //    bool _result = false;
        //    try
        //    {
        //        this.db.WsCommunityReports.InsertOnSubmit(_prmTable);
        //        this.db.SubmitChanges();

        //        _result = true;
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return _result;
        //}

        public bool EditLaporanMasyarakat(WsLaporanMasyarakat _prmTable)
        {
            bool _result = false;

            try
            {
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }
        #endregion

        #region WsContactUs

        public List<WsContactUs> GetListWsContactUs()
        {
            List<WsContactUs> _result = new List<WsContactUs>();

            try
            {
                var _query = (
                                from _table in this.db.WsContactUs
                                orderby _table.ContactUsId ascending
                                where _table.FgActive == 'Y'
                                select _table
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public List<WsContactUs> GetListWsContactUs(String _prmName)
        {
            List<WsContactUs> _result = new List<WsContactUs>();
            String _pattern = "%" + _prmName + "%";
            try
            {
                var _query = (
                                from _table in this.db.WsContactUs
                                orderby _table.ContactUsId ascending
                                where _table.FgActive == 'Y' &&
                                (SqlMethods.Like(_table.Title.Trim().ToLower(), _pattern.ToLower()))
                                select _table
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public WsContactUs GetSingleWsContactUs(Int32 _prmCode)
        {
            WsContactUs _result = null;

            try
            {
                _result = this.db.WsContactUs.FirstOrDefault(_temp => _temp.ContactUsId == _prmCode);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool DeleteMultiWsContactUs(String[] _prmCode)
        {
            bool _result = false;

            try
            {
                for (int i = 0; i < _prmCode.Length; i++)
                {
                    WsContactUs _table = this.db.WsContactUs.FirstOrDefault(_temp => _temp.ContactUsId.ToString() == _prmCode[i]);
                    this.db.WsContactUs.DeleteOnSubmit(_table);
                }
                this.db.SubmitChanges();
                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool AddWsContactUs(WsContactUs _prmTable)
        {
            bool _result = false;
            try
            {
                this.db.WsContactUs.InsertOnSubmit(_prmTable);
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool EditWsContactUs(WsContactUs _prmTable)
        {
            bool _result = false;

            try
            {
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }
        #endregion

        #region WsInformation

        public List<WsInformation> GetListWsInformation()
        {
            List<WsInformation> _result = new List<WsInformation>();

            try
            {
                var _query = (
                                from _table in this.db.WsInformations
                                orderby _table.InformationId descending
                                where _table.FgActive == 'Y'
                                select _table
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public List<WsInformation> GetListWsInformation(String _prmName)
        {
            List<WsInformation> _result = new List<WsInformation>();
            String _pattern = "%" + _prmName + "%";
            try
            {
                var _query = (
                                from _table in this.db.WsInformations
                                orderby _table.InformationId ascending
                                where _table.FgActive == 'Y' &&
                                (SqlMethods.Like(_table.InformationName.Trim().ToLower(), _pattern.ToLower()))
                                select _table
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public WsInformation GetSingleWsInformation(Int32 _prmCode)
        {
            WsInformation _result = null;

            try
            {
                _result = this.db.WsInformations.FirstOrDefault(_temp => _temp.InformationId == _prmCode);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public WsInformation GetWsInformationByLastPost()
        {
            WsInformation _result = new WsInformation();

            try
            {
                var _query = (
                                from _table in this.db.WsInformations
                                orderby _table.InformationId descending
                                where _table.FgActive == 'Y'
                                select _table
                             ).FirstOrDefault();

                _result = _query;

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool DeleteMultiWsInformation(String[] _prmCode)
        {
            bool _result = false;

            try
            {
                for (int i = 0; i < _prmCode.Length; i++)
                {
                    WsInformation _table = this.db.WsInformations.FirstOrDefault(_temp => _temp.InformationId.ToString() == _prmCode[i]);
                    this.db.WsInformations.DeleteOnSubmit(_table);
                }
                this.db.SubmitChanges();
                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool AddWsInformation(WsInformation _prmTable)
        {
            bool _result = false;
            try
            {
                this.db.WsInformations.InsertOnSubmit(_prmTable);
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool EditWsInformation(WsInformation _prmTable)
        {
            bool _result = false;

            try
            {
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }
        #endregion

        #region WsNew

        public List<WsNew> GetListWsNew()
        {
            List<WsNew> _result = new List<WsNew>();

            try
            {
                var _query = (
                                from _table in this.db.WsNews
                                orderby _table.NewsId descending
                                where _table.FgActive == 'Y'
                                select _table
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public WsNew GetWsNewByLastPost()
        {
            WsNew _result = new WsNew();

            try
            {
                var _query = (
                                from _table in this.db.WsNews
                                orderby _table.NewsId descending
                                where _table.FgActive == 'Y'
                                select _table
                             ).FirstOrDefault();

                _result = _query;

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public List<WsNew> GetListWsNew(String _prmName)
        {
            List<WsNew> _result = new List<WsNew>();
            String _pattern = "%" + _prmName + "%";
            try
            {
                var _query = (
                                from _table in this.db.WsNews
                                orderby _table.NewsId ascending
                                where _table.FgActive == 'Y' &&
                                (SqlMethods.Like(_table.NewsName.Trim().ToLower(), _pattern.ToLower()))
                                select _table
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public WsNew GetSingleWsNew(Int32 _prmCode)
        {
            WsNew _result = null;

            try
            {
                _result = this.db.WsNews.FirstOrDefault(_temp => _temp.NewsId == _prmCode && _temp.FgActive == 'Y');
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public WsNew GetSingleWsNewLast()
        {
            WsNew _result = null;
            try
            {
                _result = this.db.WsNews.Where(y => y.FgActive == 'Y').OrderByDescending(x => x.NewsId).FirstOrDefault();
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool DeleteMultiWsNew(String[] _prmCode)
        {
            bool _result = false;

            try
            {
                for (int i = 0; i < _prmCode.Length; i++)
                {
                    WsNew _table = this.db.WsNews.FirstOrDefault(_temp => _temp.NewsId.ToString() == _prmCode[i]);
                    this.db.WsNews.DeleteOnSubmit(_table);
                }
                this.db.SubmitChanges();
                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool AddWsNew(WsNew _prmTable)
        {
            bool _result = false;
            try
            {
                this.db.WsNews.InsertOnSubmit(_prmTable);
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool EditWsNew(WsNew _prmTable)
        {
            bool _result = false;

            try
            {
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }
        #endregion

        #region WsRegulation

        public List<WsRegulation> GetListWsRegulation()
        {
            List<WsRegulation> _result = new List<WsRegulation>();

            try
            {
                var _query = (
                                from _table in this.db.WsRegulations
                                orderby _table.NoUrut ascending
                                where _table.FgActive == 'Y'
                                select _table
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public WsRegulation GetSingleWsRegulation(Int32 _prmCode)
        {
            WsRegulation _result = null;

            try
            {
                _result = this.db.WsRegulations.FirstOrDefault(_temp => _temp.NoID == _prmCode);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool DeleteMultiWsRegulation(String[] _prmCode)
        {
            bool _result = false;

            try
            {
                for (int i = 0; i < _prmCode.Length; i++)
                {
                    WsRegulation _table = this.db.WsRegulations.FirstOrDefault(_temp => _temp.NoID.ToString() == _prmCode[i]);
                    this.db.WsRegulations.DeleteOnSubmit(_table);
                }
                this.db.SubmitChanges();
                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool AddWsRegulation(WsRegulation _prmTable)
        {
            bool _result = false;
            try
            {
                this.db.WsRegulations.InsertOnSubmit(_prmTable);
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool EditWsRegulation(WsRegulation _prmTable)
        {
            bool _result = false;

            try
            {
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }
        #endregion

        #region WsStructure

        public List<WsStructure> GetListWsStructure()
        {
            List<WsStructure> _result = new List<WsStructure>();

            try
            {
                var _query = (
                                from _table in this.db.WsStructures
                                orderby _table.StructureId ascending
                                where _table.FgActive == 'Y'
                                select _table
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public WsStructure GetSingleWsStructure(Int32 _prmCode)
        {
            WsStructure _result = null;

            try
            {
                _result = this.db.WsStructures.FirstOrDefault(_temp => _temp.StructureId == _prmCode);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool DeleteMultiWsStructure(String[] _prmCode)
        {
            bool _result = false;

            try
            {
                for (int i = 0; i < _prmCode.Length; i++)
                {
                    WsStructure _table = this.db.WsStructures.FirstOrDefault(_temp => _temp.StructureId.ToString() == _prmCode[i]);
                    this.db.WsStructures.DeleteOnSubmit(_table);
                }
                this.db.SubmitChanges();
                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool AddWsStructure(WsStructure _prmTable)
        {
            bool _result = false;
            try
            {
                this.db.WsStructures.InsertOnSubmit(_prmTable);
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool EditWsStructure(WsStructure _prmTable)
        {
            bool _result = false;

            try
            {
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }
        #endregion

        #region WsUndangUndang

        public List<WsUndangUndang> GetListWsUndangUndang()
        {
            List<WsUndangUndang> _result = new List<WsUndangUndang>();

            try
            {
                var _query = (
                                from _table in this.db.WsUndangUndangs
                                orderby _table.NoUrut ascending
                                select _table
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public WsUndangUndang GetSingleWsUndangUndang(Int32 _prmCode)
        {
            WsUndangUndang _result = null;

            try
            {
                _result = this.db.WsUndangUndangs.FirstOrDefault(_temp => _temp.NoID == _prmCode);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool DeleteMultiWsUndangUndang(String[] _prmCode)
        {
            bool _result = false;

            try
            {
                for (int i = 0; i < _prmCode.Length; i++)
                {
                    WsUndangUndang _table = this.db.WsUndangUndangs.FirstOrDefault(_temp => _temp.NoID.ToString() == _prmCode[i]);
                    this.db.WsUndangUndangs.DeleteOnSubmit(_table);
                }
                this.db.SubmitChanges();
                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool AddWsUndangUndang(WsUndangUndang _prmTable)
        {
            bool _result = false;
            try
            {
                this.db.WsUndangUndangs.InsertOnSubmit(_prmTable);
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool EditWsUndangUndang(WsUndangUndang _prmTable)
        {
            bool _result = false;

            try
            {
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }
        #endregion

        #region WsZonaIntegritas

        public List<WsZonaIntegrita> GetListWsZonaIntegritas()
        {
            List<WsZonaIntegrita> _result = new List<WsZonaIntegrita>();

            try
            {
                var _query = (
                                from _table in this.db.WsZonaIntegritas
                                orderby _table.NoUrut ascending
                                select _table
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public WsZonaIntegrita GetSingleWsZonaIntegritas(Int32 _prmCode)
        {
            WsZonaIntegrita _result = null;

            try
            {
                _result = this.db.WsZonaIntegritas.FirstOrDefault(_temp => _temp.NoID == _prmCode);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool DeleteMultiWsZonaIntegritas(String[] _prmCode)
        {
            bool _result = false;

            try
            {
                for (int i = 0; i < _prmCode.Length; i++)
                {
                    WsZonaIntegrita _table = this.db.WsZonaIntegritas.FirstOrDefault(_temp => _temp.NoID.ToString() == _prmCode[i]);
                    this.db.WsZonaIntegritas.DeleteOnSubmit(_table);
                }
                this.db.SubmitChanges();
                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool AddWsZonaIntegritas(WsZonaIntegrita _prmTable)
        {
            bool _result = false;
            try
            {
                this.db.WsZonaIntegritas.InsertOnSubmit(_prmTable);
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool EditWsZonaIntegritas(WsZonaIntegrita _prmTable)
        {
            bool _result = false;

            try
            {
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        #endregion

        #region WsDPO

        public List<WsDPO> GetListWsDPO()
        {
            List<WsDPO> _result = new List<WsDPO>();

            try
            {
                var _query = (
                                from _table in this.db.WsDPOs
                                orderby _table.DPOId descending
                                select _table
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public WsDPO GetWsDPOByLastPost()
        {
            WsDPO _result = new WsDPO();

            try
            {
                var _query = (
                                from _table in this.db.WsDPOs
                                orderby _table.DPOId descending
                                where _table.FgActive == 'Y'
                                select _table
                             ).FirstOrDefault();

                _result = _query;

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public WsDPO GetSingleWsDPO(Int32 _prmCode)
        {
            WsDPO _result = null;

            try
            {
                _result = this.db.WsDPOs.FirstOrDefault(_temp => _temp.DPOId == _prmCode);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool DeleteMultiWsDPO(String[] _prmCode)
        {
            bool _result = false;

            try
            {
                for (int i = 0; i < _prmCode.Length; i++)
                {
                    WsDPO _table = this.db.WsDPOs.FirstOrDefault(_temp => _temp.DPOId.ToString() == _prmCode[i]);
                    this.db.WsDPOs.DeleteOnSubmit(_table);
                }
                this.db.SubmitChanges();
                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool AddWsDPO(WsDPO _prmTable)
        {
            bool _result = false;
            try
            {
                this.db.WsDPOs.InsertOnSubmit(_prmTable);
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool EditWsDPO(WsDPO _prmTable)
        {
            bool _result = false;

            try
            {
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        #endregion

        #region WsLinks

        public List<WsLink> GetListWsLink()
        {
            List<WsLink> _result = new List<WsLink>();

            try
            {
                var _query = (
                                from _table in this.db.WsLinks
                                orderby _table.NoID ascending
                                where _table.FgActive == 'Y'
                                select _table
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public WsLink GetSingleWsLink(Int32 _prmCode)
        {
            WsLink _result = null;

            try
            {
                _result = this.db.WsLinks.FirstOrDefault(_temp => _temp.NoID == _prmCode);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool DeleteMultiWsLink(String[] _prmCode)
        {
            bool _result = false;

            try
            {
                for (int i = 0; i < _prmCode.Length; i++)
                {
                    WsLink _table = this.db.WsLinks.FirstOrDefault(_temp => _temp.NoID.ToString() == _prmCode[i]);
                    this.db.WsLinks.DeleteOnSubmit(_table);
                }
                this.db.SubmitChanges();
                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool AddWsLink(WsLink _prmTable)
        {
            bool _result = false;
            try
            {
                this.db.WsLinks.InsertOnSubmit(_prmTable);
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool EditWsLink(WsLink _prmTable)
        {
            bool _result = false;

            try
            {
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }
        #endregion

        #region WsInfoPenyidikan

        public List<WsInfoPenyidikan> GetListWsInfoPenyidikan()
        {
            List<WsInfoPenyidikan> _result = new List<WsInfoPenyidikan>();

            try
            {
                var _query = (
                                from _table in this.db.WsInfoPenyidikans
                                orderby _table.InfoPenyidikanId ascending
                                select _table
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public WsInfoPenyidikan GetSingleWsInfoPenyidikan(Int32 _prmCode)
        {
            WsInfoPenyidikan _result = null;

            try
            {
                _result = this.db.WsInfoPenyidikans.FirstOrDefault(_temp => _temp.InfoPenyidikanId == _prmCode);
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool DeleteMultiWsInfoPenyidikan(String[] _prmCode)
        {
            bool _result = false;

            try
            {
                for (int i = 0; i < _prmCode.Length; i++)
                {
                    WsInfoPenyidikan _table = this.db.WsInfoPenyidikans.FirstOrDefault(_temp => _temp.InfoPenyidikanId.ToString() == _prmCode[i]);
                    this.db.WsInfoPenyidikans.DeleteOnSubmit(_table);
                }
                this.db.SubmitChanges();
                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool AddWsInfoPenyidikan(WsInfoPenyidikan _prmTable)
        {
            bool _result = false;
            try
            {
                this.db.WsInfoPenyidikans.InsertOnSubmit(_prmTable);
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool EditWsInfoPenyidikan(WsInfoPenyidikan _prmTable)
        {
            bool _result = false;

            try
            {
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        #endregion

        #region WsHimbauan

        public List<WsHimbauan> GetListWsHimbauan()
        {
            List<WsHimbauan> _result = new List<WsHimbauan>();

            try
            {
                var _query = (
                    from _WsHimbauan in this.db.WsHimbauans
                    orderby _WsHimbauan.HimbauanId descending
                    select _WsHimbauan
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public List<WsHimbauan> GetListWsHimbauanActive()
        {
            List<WsHimbauan> _result = new List<WsHimbauan>();

            try
            {
                var _query = (
                    from _WsHimbauan in this.db.WsHimbauans
                    orderby _WsHimbauan.HimbauanId descending
                    where _WsHimbauan.FgActive == "Y"
                    select _WsHimbauan
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public List<WsHimbauan> GetListWsHimbauan(String _prmName)
        {
            List<WsHimbauan> _result = new List<WsHimbauan>();
            String _pattern = "%" + _prmName + "%";
            try
            {
                var _query = (
                                from _MsPenyidikHd in this.db.WsHimbauans
                                orderby _MsPenyidikHd.HimbauanId ascending
                                where _MsPenyidikHd.FgActive == "Y" &&
                                (SqlMethods.Like(_MsPenyidikHd.HimbauanName.Trim().ToLower(), _pattern.ToLower()))
                                select _MsPenyidikHd
                             );

                foreach (var _row in _query)
                    _result.Add(_row);

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public WsHimbauan GetSingleWsHimbauan(String _prmCode)
        {
            WsHimbauan _result = null;

            try
            {
                _result = this.db.WsHimbauans.FirstOrDefault(_temp => _temp.HimbauanId == Convert.ToInt32(_prmCode));
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public WsHimbauan GetlastWsHimbauan()
        {
            WsHimbauan _result = null;

            try
            {
                var _query = (
                    from _WsHimbauan in this.db.WsHimbauans
                    orderby _WsHimbauan.HimbauanId descending
                    where _WsHimbauan.FgActive == "Y"
                    select _WsHimbauan
                             );
                foreach (var _item in _query)
                {
                    _result = new WsHimbauan();
                    _result = _item;
                    break;
                }

            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool DeleteMultiWsHimbauan(String[] _prmCode)
        {
            bool _result = false;

            try
            {
                for (int i = 0; i < _prmCode.Length; i++)
                {
                    WsHimbauan _table = this.db.WsHimbauans.FirstOrDefault(_temp => _temp.HimbauanId.ToString() == _prmCode[i]);
                    this.db.WsHimbauans.DeleteOnSubmit(_table);
                }
                this.db.SubmitChanges();
                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool AddWsHimbauan(WsHimbauan _prmTable)
        {
            bool _result = false;
            try
            {
                this.db.WsHimbauans.InsertOnSubmit(_prmTable);
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        public bool EditWsHimbauan(WsHimbauan _prmTable)
        {
            bool _result = false;

            try
            {
                this.db.SubmitChanges();

                _result = true;
            }
            catch (Exception ex)
            {
            }
            return _result;
        }

        #endregion

        //public WebsiteContentBL GetSingleWsContactUs(string p)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
