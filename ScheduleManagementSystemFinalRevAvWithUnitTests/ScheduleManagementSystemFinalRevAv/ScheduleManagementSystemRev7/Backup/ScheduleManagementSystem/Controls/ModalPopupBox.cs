using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.ComponentModel;
using System.Web.UI.WebControls;
using System.IO;

namespace ScheduleManagementSystem.Controls
{
    [ToolboxData("<{0}:modalpopupbox runat='server' id='mpb0' Width='500px' height='200px'></{0}:modalpopupbox>"), Designer(typeof(ModalPopupBoxDesigner))]
    public class ModalPopupBox : Panel
    {
        /// <summary>
        /// The title displayed in the top bar.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [Browsable(true), Category("Appearance"), DefaultValue(""), Description("The title of the box.")]
        public string Title { get; set; }

        /// <summary>
        /// Toggles the Close window button.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [Browsable(true), Category("Appearance"), DefaultValue(true), Description("Show the close button.")]
        public bool ShowClose { get; set; }

        [Browsable(true), Category("Appearance"), DefaultValue(""), Description("Required if using the Close button.")]
        public string BehaviorId { get; set; }

        public ModalPopupBox()
        {
            this.Width = Unit.Parse("500px");
            this.Height = Unit.Parse("200px");
            Title = "STAR | Altair Global Relocation";
            ShowClose = true;
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {

            //Capture the default output of the Panel
            StringWriter sw = new StringWriter();
            HtmlTextWriter buffer = new HtmlTextWriter(sw);
            base.RenderContents(buffer);

            string panelContents = sw.ToString();


            System.Web.UI.HtmlControls.HtmlGenericControl container = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
            container.Attributes.Add("class", "container");


            //===========================================================
            //   Title Bar
            //===========================================================
            System.Web.UI.HtmlControls.HtmlGenericControl titlebar = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
            titlebar.Attributes.Add("class", "titlebar");
            titlebar.Style.Add("min-width", this.Width.ToString());

            Label title = new Label();
            title.Text = Title;

            //Add the Control to the panel:
            titlebar.Controls.Add(title);

            if ((ShowClose))
            {
                LinkButton lnkclose = new LinkButton();
                lnkclose.ID = "lnkClosePopup";
                lnkclose.CssClass = "close";
                lnkclose.ToolTip = "close this window";
                lnkclose.OnClientClick = "javascript:$find('" + BehaviorId + "').hide();";
                titlebar.Controls.Add(lnkclose);
            }
            //===========================================================

            //===========================================================
            //   Body
            //===========================================================
            System.Web.UI.HtmlControls.HtmlGenericControl body = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
            body.Style.Add("padding", "10px");
            body.InnerHtml = string.IsNullOrEmpty(panelContents) ? "&nbsp;" : panelContents;
            //===========================================================

            //Add the controls to the container div:
            container.Controls.Add(titlebar);
            container.Controls.Add(body);

            this.Style.Add("display", "none");
            this.Style.Add("min-width", this.Width.ToString());
            this.Style.Add("min-height", this.Height.ToString());
            this.CssClass.Insert(0, "popup ");
            this.Attributes.Add("class", "popup");


            base.RenderBeginTag(writer);
            container.RenderControl(writer);
            base.RenderEndTag(writer);

        }


    }

    public class ModalPopupBoxDesigner : System.Web.UI.Design.WebControls.PanelContainerDesigner
    {
        /// <summary>
        /// Provide a design-time caption for the panel.
        /// </summary>
        public override string FrameCaption
        {
            get
            {
                // If the FrameCaption is empty, use the panel control ID.
                string localCaption = base.FrameCaption;
                if (localCaption == null | localCaption == "")
                {
                    localCaption = ((Panel)Component).ID.ToString();
                }

                return localCaption;
            }
        }

        /// <summary>
        /// Provide a design-time border style for the panel.
        /// </summary>
        public override Style FrameStyle
        {
            get
            {
                Style styleOfFrame = base.FrameStyle;

                // If no border style is defined, define one.
                if ((styleOfFrame.BorderStyle == BorderStyle.NotSet | styleOfFrame.BorderStyle == BorderStyle.None))
                {
                    styleOfFrame.BorderStyle = BorderStyle.Outset;
                }

                return styleOfFrame;
            }
        }

    }
}
