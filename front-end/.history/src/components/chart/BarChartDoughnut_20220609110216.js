import React, { useEffect, useState } from "react";
import { CanvasJSChart } from "canvasjs-react-charts";
import axios from "axios";
import { BASE_URL } from "../../util/constants";

const BarChartDoughnut = ({project}) => {
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
    animationEnabled: true,
    title: {
      text: "Customer Satisfaction",
    },
    subtitles: [
      {
        text: "71% Positive",
        verticalAlign: "center",
        fontSize: 24,
        dockInsidePlotArea: true,
      },
    ],
    data: [
      {
        type: "doughnut",
        showInLegend: true,
        indexLabel: "{name}: {y}",
        yValueFormatString: "#,###'%'",
        dataPoints: [
          { name: "Unsatisfied", y: 5 },
          { name: "Very Unsatisfied", y: 31 },
          { name: "Very Satisfied", y: 40 },
          { name: "Satisfied", y: 17 },
          { name: "Neutral", y: 7 },
        ],
      },
    ],
  };
  return (
    <div className="mt-[30px]">
      <h2 className="text-2xl font-bold text-blue-600">Chart Doughnut</h2>
      <CanvasJSChart options={options} />
    </div>
  );
};

export default BarChartDoughnut;
