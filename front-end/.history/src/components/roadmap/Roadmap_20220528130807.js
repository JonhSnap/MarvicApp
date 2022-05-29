import format from "date-fns/format";
import getDay from "date-fns/getDay";
import parse from "date-fns/parse";
import startOfWeek from "date-fns/startOfWeek";
import React, { useMemo, useRef, useState } from "react";
import moment from "moment";
import { Calendar, momentLocalizer } from "react-big-calendar";
import "react-big-calendar/lib/css/react-big-calendar.css";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import { useListIssueContext } from "../../contexts/listIssueContext";
import "./Roadmap.scss";
import { faWindowClose } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import ReactDOM, { render } from "react-dom";
import useHover from "../../hooks/useHover";
const locales = {
  "en-US": require("date-fns/locale/en-US"),
};

const localizer = momentLocalizer(moment);
const TooltipContent = (event) => {
  return (
    <React.Fragment>
      <div className="text-black ">
        <FontAwesomeIcon icon={faWindowClose} className="pull-right" />
        <div>{event.title}</div>
        <button>Button 1</button>
        <button>Button 2</button>
      </div>
    </React.Fragment>
  );
};

function Event(event) {
  return (
    <div className="abso">
      <span>{event.title}</span>
      {<TooltipContent event={event} />}
    </div>
  );
}

const Roadmap = () => {
  const [{ issueEpics }] = useListIssueContext();

  const epicTimelines = useMemo(() => {
    return issueEpics.reduce((initialState, item) => {
      return [
        ...initialState,
        {
          title: item.summary,
          start: new Date(item.dateStarted),
          end: new Date(item.dateEnd),
        },
      ];
    }, []);
  }, [issueEpics]);
  return (
    <div className="items-center w-full p-8">
      <Calendar
        tooltipAccessor={null}
        components={{ event: Event }}
        localizer={localizer}
        events={epicTimelines}
        startAccessor="start"
        endAccessor="end"
        defaultDate={moment().toDate()}
        style={{ height: 500 }}
      />
    </div>
  );
};

export default Roadmap;
