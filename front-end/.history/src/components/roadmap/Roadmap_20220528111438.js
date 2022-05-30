import format from "date-fns/format";
import getDay from "date-fns/getDay";
import parse from "date-fns/parse";
import startOfWeek from "date-fns/startOfWeek";
import React, { useMemo, useState } from "react";
import { Calendar, dateFnsLocalizer } from "react-big-calendar";
import "react-big-calendar/lib/css/react-big-calendar.css";
import "react-datepicker/dist/react-datepicker.css";
import { useListIssueContext } from "../../contexts/listIssueContext";
import "./Roadmap.scss";

const locales = {
  "en-US": require("date-fns/locale/en-US"),
};

const localizer = dateFnsLocalizer({
  format,
  parse,
  startOfWeek,
  getDay,
  locales,
});

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
        localizer={localizer}
        events={epicTimelines}
        startAccessor="start"
        endAccessor="end"
        style={{ height: 500 }}
      />
    </div>
  );
};

export default Roadmap;
