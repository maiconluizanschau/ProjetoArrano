using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DHTMLX.Scheduler;
using DHTMLX.Common;
using DHTMLX.Scheduler.Data;
using DHTMLX.Scheduler.Controls;

using PorjetoUfsmArrano.Models;
namespace PorjetoUfsmArrano.Controllers
{
    public class CalendarController : Controller
    {
        private EventContext db = new EventContext();
        public ActionResult Index()
        {
            //Being initialized in that way, scheduler will use CalendarController.Data as a the datasource and CalendarController.Save to process changes
            var scheduler = new DHXScheduler(this);


            scheduler.LoadData = true;
            scheduler.EnableDataprocessor = true;

            return View(scheduler);
        }

        public ContentResult Data()
        {
            var data = new SchedulerAjaxData(new EventContext().Event);

            return (ContentResult)data;
        }

        public ContentResult Salvar(int? id, FormCollection actionValues)
        {
            var action = new DataAction(actionValues);

            try
            {
                var changedEvent = (Event)DHXEventsHelper.Bind(typeof(Event), actionValues);
                var data = new EventContext();


                switch (action.Type)
                {
                    //case DataActionTypes.Inserir:
                    //    data.Event.InsertOnSubmit(changedEvent);
                    //    //do insert
                    //    //action.TargetId = changedEvent.id;//assign postoperational id
                    //    break;
                    //case DataActionTypes.Deletar:
                    //    //do delete
                    //    changedEvent = data.Agenda.SingleOrDefault(ag => ag.id == action.SourceId);
                    //    data.Event.DeleteOnSubmit(changedEvent);
                    //    break;
                    //default:// "update"                          
                    //    //do update
                    //    var agendaToUpdate = data.Agenda.SingleOrDefault(ag => ag.id == action.SourceId);
                    //    DHXEventsHelper.Update(eventToUpdate, changedEvent, new List<string>() { "id" });
                    //    break;
                }
           //     data.SubmitChanges();
                action.TargetId = changedEvent.id;
            }
            catch
            {
                action.Type = DataActionTypes.Error;
            }
            return (ContentResult)new AjaxSaveResponse(action);
        }
    }
}

