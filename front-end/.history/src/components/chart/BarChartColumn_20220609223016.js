import React, { useEffect, useRef, useState } from "react";
import { CanvasJSChart } from "canvasjs-react-charts";
import axios from "axios";
import { BASE_URL } from "../../util/constants";

const BarChartColumn = ({project}) => {
    const [datapoint, setDatapoint] = useState([]);

    let ref =useRef(null)
  const dataP = async () => {
    await axios
      .get(
        `${BASE_URL}/api/Issue/StatisticIssue?idProject=${project?.id}&dateStarted=${project?.dateStarted}&dateEnd=${project?.dateEnd}`
      )
      .then((res) => {
        setDatapoint(res.data);
      });
  };
  useEffect(() => {
    dataP();
  }, [project]);
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
  const handleExportChart =()=>{
    ref.current.chart.exportChart({format: "png"})

  }
  return (
    <div className="mt-[30px]">
      <CanvasJSChart ref={ref} options={options} />
      <button  onClick={handleExportChart}  className="p-2 mt-3 text-white bg-blue-500 rounded-md hover:opacity-90">Export Chart</button>
    </div>
  );
};

export default BarChartColumn;
