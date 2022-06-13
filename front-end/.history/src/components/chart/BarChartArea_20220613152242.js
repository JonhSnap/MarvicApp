import React, { useEffect, useMemo, useRef, useState } from "react";
import { CanvasJSChart } from "canvasjs-react-charts";
import { BASE_URL } from "../../util/constants";
import axios from "axios";
const BarChartArea = ({ project, timeLine, period }) => {
  const [datapoint, setDatapoint] = useState([]);
  var dataPoints = [];
  let ref = useRef(null);

  const dateStarted = useMemo(() => {
    let today, day, month, year;
    switch (timeLine) {
      case 'project':
        return project?.dateStarted;
      case 'week':
        today = new Date();
        day = today.getDate() - 7;
        month = today.getMonth() + 1;
        year = today.getFullYear();
        return `${year}-${month}-${day}`;
      case 'month':
        today = new Date();
        day = 1;
        month = today.getMonth() + 1;
        year = today.getFullYear();
        return `${year}-${month}-${day}`;
      case 'year':
        today = new Date();
        day = 1;
        month = 1;
        year = today.getFullYear();
        return `${year}-${month}-${day}`;
      case 'custom':
        return period.dateStart;
      default:
        return;
    }
  }, [timeLine, project, period]);
  const dateEnd = useMemo(() => {
    let today, day, month, year;
    switch (timeLine) {
      case 'project':
        return project?.dateEnd;
      case 'week':
        today = new Date();
        day = today.getDate();
        month = today.getMonth() + 1;
        year = today.getFullYear();
        return `${year}-${month}-${day}`;
      case 'month':
        today = new Date();
        day = 30;
        month = today.getMonth() + 1;
        if (month === 2) {
          day = 29;
        } else if (month < 8 && month % 2 === 1) {
          day = 31;
        } else if (month >= 8 && month % 2 === 0) {
          day = 31;
        }
        year = today.getFullYear();
        return `${year}-${month}-${day}`;
      case 'year':
        today = new Date();
        day = 31;
        month = 12;
        year = today.getFullYear();
        return `${year}-${month}-${day}`;
      case 'custom':
        return period.dateEnd;
      default:
        return;
    }
  }, [timeLine, project, period]);

  useEffect(() => {
    const dataP = async () => {
      await axios
        .get(
          `${BASE_URL}/api/Issue/StatisticIssueArchived?idProject=${project?.id}&dateStarted=${dateStarted}&dateEnd=${dateEnd}`
        )
        .then((res) => {
          setDatapoint(res.data);
        });
    };
    dataP();
  }, [project, dateStarted, dateEnd]);

  if (datapoint && datapoint.length > 0) {
    for (var i = 0; i < datapoint.length; i++) {
      dataPoints.push({
        x: new Date(datapoint[i].x),
        y: datapoint[i].y,
      });
    }
  }


  const options = {
    theme: "light2",
    title: {
      text: `Issue Satisfaction Archive - ${project?.dateEnd.slice(0, 4)}`,
    },
    toolTip: {
      shared: true,
    },
    data: [
      {
        type: "area",
        // showInLegend: true,
        xValueFormatString: "MMM YYYY",
        yValueFormatString: "#,##0.##",
        dataPoints: dataPoints,
      },
    ],
  };

  const handleExportChart = () => {
    ref.current.chart.exportChart({ format: "png" })

  }
  if (datapoint.length === 0) {
    return (
      <h3 className="text-center font-bold text-[20px]">No issue for the period</h3>
    )
  }

  return (
    <div className="" >
      <h2 className="flex justify-center text-[40px] font-semibold archive-area ">Archive</h2>
      <CanvasJSChart ref={ref} options={options} />
      <button onClick={handleExportChart} className="p-2 mt-3 text-white bg-blue-500 rounded-md hover:opacity-90">Export Chart</button>
    </div>
  );
};

export default BarChartArea;
