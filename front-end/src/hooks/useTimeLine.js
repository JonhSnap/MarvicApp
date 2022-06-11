import { useMemo } from "react";


export default function useTimeLine(project, timeLine, period) {
    const dateStarted = useMemo(() => {
        let today, day, month, year;
        switch (timeLine) {
            case 'project':
                return project?.dateStarted;
            case 'week':
                today = new Date();
                day = today.getDate() - 7;
                month = today.getMonth() + 1;
                year = today.getFullYear();
                return `${year}-${month}-${day}`;
            case 'month':
                today = new Date();
                day = 1;
                month = today.getMonth() + 1;
                year = today.getFullYear();
                return `${year}-${month}-${day}`;
            case 'year':
                today = new Date();
                day = 1;
                month = 1;
                year = today.getFullYear();
                return `${year}-${month}-${day}`;
            case 'custom':
                return period.dateStart;
            default:
                return;
        }
    }, [timeLine, project, period]);
    const dateEnd = useMemo(() => {
        let today, day, month, year;
        switch (timeLine) {
            case 'project':
                return project?.dateEnd;
            case 'week':
                today = new Date();
                day = today.getDate();
                month = today.getMonth() + 1;
                year = today.getFullYear();
                return `${year}-${month}-${day}`;
            case 'month':
                today = new Date();
                day = 30;
                month = today.getMonth() + 1;
                if (month === 2) {
                    day = 29;
                } else if (month < 8 && month % 2 === 1) {
                    day = 31;
                } else if (month >= 8 && month % 2 === 0) {
                    day = 31;
                }
                year = today.getFullYear();
                return `${year}-${month}-${day}`;
            case 'year':
                today = new Date();
                day = 31;
                month = 12;
                year = today.getFullYear();
                return `${year}-${month}-${day}`;
            case 'custom':
                return period.dateEnd;
            default:
                return;
        }
    }, [timeLine, project, period]);
    return [dateStarted, dateEnd];
}