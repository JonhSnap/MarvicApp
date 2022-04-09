import React, { lazy, Suspense } from "react";
import { Routes, Route } from "react-router-dom";
import Login from "./components/auth/Login";
import Register from "./components/auth/Register";
import Home from "./components/home/Home";
// import Main from './components/layouts/Main';

// const YourWord = lazy(() => import('./pages/YourWordPage'));
// const ProjectsPage = lazy(() => import('./pages/ProjectsPage'));

function App() {
  return (
    <>
      <Routes>
        <Route path="/" element={<Home></Home>}></Route>
        <Route path="/login" element={<Login></Login>}></Route>
        <Route path="/register" element={<Register></Register>}></Route>
      </Routes>
    </>
    // <Suspense fallback={<>Component fallback</>}>
    //   <Routes>
    //     <Route element={<Main></Main>}>
    //       <Route path={'/'} element={<YourWord></YourWord>}></Route>
    //       <Route path={'/projects'} element={<ProjectsPage></ProjectsPage>}></Route>
    //     </Route>
    //   </Routes>
    // </Suspense>
  );
}

export default App;
