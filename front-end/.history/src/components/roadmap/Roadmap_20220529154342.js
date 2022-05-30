import React, { useMemo, useState } from "react";
import moment from "moment";
import { Calendar, momentLocalizer } from "react-big-calendar";
import "react-big-calendar/lib/css/react-big-calendar.css";
import "react-datepicker/dist/react-datepicker.css";
import { useListIssueContext } from "../../contexts/listIssueContext";
import "./Roadmap.scss";
import { Link } from "react-router-dom";
import { useSelector } from "react-redux";
const locales = {
  "en-US": require("date-fns/locale/en-US"),
};

const localizer = momentLocalizer(moment);
const TooltipContent = ({ event, issueEpics, projects }) => {
  // console.log("issueEpics", issueEpics);
  // console.log("event", event);
  const ToBoard = issueEpics.find((isEpic) => isEpic.summary === event.title);
  const keyToBoard = projects.find(
    (project) => project.id === ToBoard.id_Project
  );
  console.log("ToBoard", ToBoard);
  // console.log("projects", projects);
  return (
    <Link to={`/projects/board/${keyToBoard.key}/${ToBoard.id}`}>
      <div className=" hover:bg-slate-200 text-black bg-slate-100 absolute z-50 rounded-lg inline-block px-5 top-0 left-[125%] ">
        To Board {event.title}
      </div>
    </Link>
  );
};

function Event(event) {
  const [showTooltip, setShowTooltip] = useState(false);
  const [{ issueEpics }] = useListIssueContext();
  const projects = useSelector((state) => state.projects.projects);
  return (
    <div className="">
      <span className="relative" onClick={() => setShowTooltip(!showTooltip)}>
        {event.title}
        {showTooltip && (
          <TooltipContent
            projects={projects}
            issueEpics={issueEpics}
            event={event}
          />
        )}
      </span>
    </div>
  );
}

const Roadmap = ({ issueEpics, epicSelected, setEpicSelected }) => {
  // const [{ issueEpics }] = useListIssueContext();
  // console.log("epicSelected", epicSelected);

  const epicTimelines = useMemo(() => {
    if (epicSelected.filter.length > 0) {
      return epicSelected.issues
        .filter((item) => epicSelected.filter.includes(item.id))
        .reduce((initialState, item) => {
          return [
            ...initialState,
            {
              title: item.summary,
              start: new Date(item.dateStarted),
              end: new Date(item.dateEnd),
            },
          ];
        }, []);
    } else {
      return epicSelected.issues.reduce((initialState, item) => {
        return [
          ...initialState,
          {
            title: item.summary,
            start: new Date(item.dateStarted),
            end: new Date(item.dateEnd),
          },
        ];
      }, []);
    }
  }, [epicSelected]);
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
