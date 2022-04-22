-- Group by id Assignee of Project id = 'a42b223b-faec-48e3-8e28-51fe1b22fa7c'
select i.Id_Assignee, COUNT(i.Id_Project)
from Issue i
where i.Id_Project = 'a42b223b-faec-48e3-8e28-51fe1b22fa7c'
GROUP BY i.Id_Assignee





