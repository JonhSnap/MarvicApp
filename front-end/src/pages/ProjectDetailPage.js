import React from 'react'
import { useParams } from 'react-router-dom'

function ProjectDetailPage() {
  const idProject = useParams().id;
  console.log('id project ~', idProject);

  return (
    <div>ProjectDetailPage</div>
  )
}

export default ProjectDetailPage