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
const TooltipContent = ({ event }) => {
  return (
    <div className=" hover:bg-slate-200 text-black bg-slate-100 absolute z-50 rounded-lg inline-block px-5 top-0 left-[125%] ">
      To Board {event.title}
    </div>
  );
};

function Event(event) {
  const [showTooltip, setShowTooltip] = useState(false);

  const closeTooltip = () => {
    setShowTooltip(false);
  };

  return (
    <div className="">
      <span className="relative" onClick={() => setShowTooltip(!showTooltip)}>
        {event.title}
        {showTooltip && <TooltipContent event={event} />}
      </span>
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
