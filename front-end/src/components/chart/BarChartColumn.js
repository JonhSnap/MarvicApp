import React, { useEffect, useMemo, useRef, useState } from "react";
import { CanvasJSChart } from "canvasjs-react-charts";
import axios from "axios";
import { BASE_URL } from "../../util/constants";
import useTimeLine from "../../hooks/useTimeLine";

const BarChartColumn = ({ project, timeLine, period }) => {
  const [datapoint, setDatapoint] = useState([]);
  const [dateStarted, dateEnd] = useTimeLine(project, timeLine, period);

  let ref = useRef(null)
  useEffect(() => {
    const dataP = async () => {
      await axios
        .get(
          `${BASE_URL}/api/Issue/StatisticIssue?idProject=${project?.id}&dateStarted=${dateStarted}&dateEnd=${dateEnd}`
        )
        .then((res) => {
          setDatapoint(res.data);
        });
    };
    dataP();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [project, dateStarted, dateEnd]);
  const options = {
    title: {
      text: "Issue Satisfaction",
    },
    data: [
      {
        // Change type to "doughnut", "line", "splineArea", etc.
        type: "column",
        dataPoints: datapoint,
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
    <div className="mt-[30px]">
      <CanvasJSChart ref={ref} options={options} />
      <button onClick={handleExportChart} className="p-2 mt-3 text-white bg-blue-500 rounded-md hover:opacity-90">Export Chart</button>
    </div>
  );
};

export default BarChartColumn;
