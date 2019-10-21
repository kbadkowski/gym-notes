import DashboardLayout from "@/layout/dashboard/DashboardLayout.vue";
import NotFound from "@/pages/NotFoundPage.vue";

const Dashboard = () => import("@/pages/Dashboard.vue");
const Profile = () => import("@/pages/Profile.vue");
const GroupsOfExercise = () => import("@/pages/GroupsOfExercise.vue");
const Diet = () => import( "@/pages/Diet.vue");
const Weight = () => import( "@/pages/Weight.vue");
const Tasks = () => import( "@/pages/Tasks.vue");


const routes = [
  {
    path: "/",
    component: DashboardLayout,
    redirect: "/dashboard",
    children: [
      {
        path: "dashboard",
        name: "dashboard",
        component: Dashboard
      },
      {
        path: "profile",
        name: "profile",
        component: Profile
      },
      {
        path: "groupsOfExercise",
        name: "groups of exercise",
        component: GroupsOfExercise
      },
      {
        path: "diet",
        name: "diet",
        component: Diet
      },
      {
        path: "weight",
        name: "weight",
        component: Weight
      },
      {
        path: "tasks",
        name: "tasks",
        component: Tasks
      }
    ]
  },
  { path: "*", component: NotFound },
];

/**
 * Asynchronously load view (Webpack Lazy loading compatible)
 * The specified component must be inside the Views folder
 * @param  {string} name  the filename (basename) of the view to load.
function view(name) {
   var res= require('../components/Dashboard/Views/' + name + '.vue');
   return res;
};**/

export default routes;
