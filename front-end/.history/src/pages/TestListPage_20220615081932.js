import React, { useEffect, useState } from "react";

const TestListPage = () => {
  const [getTest, setGetTest] = useState();
  useEffect(() => {
    document.title = "Test-result";
  }, []);
  return <div className="w-[1320px] mx-auto p-4">List-Page</div>;
};

export default TestListPage;
