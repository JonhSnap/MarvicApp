import React, { lazy, Suspense } from 'react'
import { Routes, Route } from 'react-router-dom'
import Main from './components/layouts/Main';

const YourWord = lazy(() => import('./pages/YourWordPage'));
const ProjectsPage = lazy(() => import('./pages/ProjectsPage'));

function App() {
  return (
    <Suspense fallback={<>Component fallback</>}>
      <Routes>
        <Route element={<Main></Main>}>
          <Route path={'/'} element={<YourWord></YourWord>}></Route>
          <Route path={'/projects'} element={<ProjectsPage></ProjectsPage>}></Route>
        </Route>
      </Routes>
    </Suspense>
  );
}

export default App;
