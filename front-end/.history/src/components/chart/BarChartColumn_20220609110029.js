import React, { useEffect, useState } from "react";
import { CanvasJSChart } from "canvasjs-react-charts";
import axios from "axios";
import { BASE_URL } from "../../util/constants";

const BarChartColumn = ({project}) => {
    const [datapoint, setDatapoint] = useState([]);
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
      text: "Basic Column Chart",
    },
    data: [
      {
        // Change type to "doughnut", "line", "splineArea", etc.
        type: "column",
        dataPoints: datapoint,
      },
    ],
  };
  return (
    <div className="mt-[30px]">
      <h2 className="text-2xl font-bold text-blue-600">
        Chart column Year month day
      </h2>
      <CanvasJSChart options={options} />
    </div>
  );
};

export default BarChartColumn;
