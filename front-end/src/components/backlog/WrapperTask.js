import React, { memo, useMemo } from 'react'
import { NIL } from 'uuid';
import { v4 } from 'uuid'
import { useListIssueContext } from '../../contexts/listIssueContext';
import TaskItemComponent from './TaskItemComponent'

function WrapperTask({ members, project, issues }) {
  const [{ issueEpics }] = useListIssueContext();

  return (
    <div className='min-h-[40px] bg-white'>
      {
        issues?.length > 0 &&
        issues.map(item => (
          <TaskItemComponent members={members} key={v4()} project={project} issueEpics={issueEpics} issue={item} />
        ))
      }
    </div>
  )
}

export default memo(WrapperTask)