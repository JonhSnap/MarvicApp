import React, { lazy, Suspense } from "react";
import { Routes, Route } from "react-router-dom";
import Main from "./components/layouts/Main";
import ProjectDetailPage from "./pages/ProjectDetailPage";

const YourWorkPage = lazy(() => import("./pages/YourWorkPage"));
const ProjectsPage = lazy(() => import("./pages/ProjectsPage"));
const LoginPage = lazy(() => import("./pages/LoginPage"));
const RegisterPage = lazy(() => import("./pages/RegisterPage"));
const Board = lazy(() => import("./pages/Board"));
const TutorialPage = lazy(() => import("./pages/TutorialPage"));
const TestPage = lazy(() => import("./pages/TestPage"));
const Backlog = lazy(() => import("./pages/Backlog"));

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
          <Route
            path="/projects/:id"
            element={<ProjectDetailPage></ProjectDetailPage>}
          ></Route>
        </Route>
        <Route path="/login" element={<LoginPage></LoginPage>}></Route>
        <Route path="/register" element={<RegisterPage></RegisterPage>}></Route>
        <Route path="/board" element={<Board></Board>}></Route>
        <Route path="/tutorial" element={<TutorialPage></TutorialPage>}></Route>
        <Route path="/test" element={<TestPage></TestPage>}></Route>
        <Route path="/backlog" element={<Backlog></Backlog>}></Route>
      </Routes>
    </Suspense>
  );
}

export default App;
