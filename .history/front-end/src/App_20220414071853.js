import React, { lazy, Suspense } from "react";
import { Routes, Route } from "react-router-dom";
import Main from "./components/layouts/Main";
// import LoginPage from "./pages/LoginPage";
// import ProjectsPage from './pages/ProjectsPage'
// import YourWorkPage from './pages/YourWorkPage'

const YourWorkPage = lazy(() => import("./pages/YourWorkPage"));
const ProjectsPage = lazy(() => import("./pages/ProjectsPage"));
// const LoginPage = lazy(() => import("./pages/LoginPage"));
// const RegisterPage = lazy(() => import("./pages/RegisterPage"));
const TutorialPage = lazy(() => import("./pages/TutorialPage"));
const TestPage = lazy(() => import("./pages/TestPage"));

function App() {
  return (
    <Suspense fallback={<>Fall back component</>}>
      <Routes>
        <Route path="/" element={<Main></Main>}>
          <Route path="/" element={<YourWorkPage></YourWorkPage>}></Route>
          <Route
            path="/projects"
            element={<ProjectsPage></ProjectsPage>}
          ></Route>
        </Route>
        <Route path="/login" element={<LoginPage></LoginPage>}></Route>
        <Route path="/register" element={<RegisterPage></RegisterPage>}></Route>
        <Route path="/tutorial" element={<TutorialPage></TutorialPage>}></Route>
        <Route path="/test" element={<TestPage></TestPage>}></Route>
      </Routes>
    </Suspense>
  );
}

export default App;
