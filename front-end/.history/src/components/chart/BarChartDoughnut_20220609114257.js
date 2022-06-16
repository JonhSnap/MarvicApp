import React, { useEffect, useRef, useState } from "react";
import { CanvasJSChart } from "canvasjs-react-charts";
import axios from "axios";
import { BASE_URL } from "../../util/constants";

const BarChartDoughnut = ({project}) => {
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
        dataPoints: datapoint,
      },
    ],
  };

  const handleExportChart =()=>{
    ref.current.chart.exportChart({format: "png"})

  }
  return (
    <div className="mt-[30px]">
      <h2 className="text-2xl font-bold text-blue-600">Chart Doughnut</h2>
      <CanvasJSChart options={options} />
      <button  onClick={handleExportChart}  className="p-2 mt-3 text-white bg-blue-500 rounded-md hover:opacity-90">Export Chart</button>
    </div>
  );
};

export default BarChartDoughnut;
