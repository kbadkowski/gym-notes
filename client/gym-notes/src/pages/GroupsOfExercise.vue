<template>
  <div class="row">
    <h3>List of exercises</h3>
    <div class="col-12 overflow-auto">
      <card type="tasks">
        <template slot="header">
          <h6 class="title d-inline">{{$t('groupsOfExercises', {count: tableData.length})}}</h6>
        </template>
        <div class="table-full-width bg-2 overflow-auto">
          <base-table :data="tableData" thead-classes="text-primary">
            <template slot-scope="{row}">
              <td>
                <p class="text-primary">{{row.day}}</p>
                <p class="title">{{row.group}}</p>
              </td>
              <td class="td-actions text-right">
                <base-dropdown
                  menu-on-right
                  tag="div"
                  title-classes="btn btn-link btn-icon"
                  aria-label="Settings menu"
                >
                  <i slot="title" class="tim-icons icon-pencil"></i>
                  <a class="dropdown-item" href="#edit">{{$t('dropdownPencil.edit')}}</a>
                  <a class="dropdown-item" href="#delete">{{$t('dropdownPencil.delete')}}</a>
                </base-dropdown>
              </td>
            </template>
          </base-table>
        </div>
        <div class="pt-3 mt-3">
          <base-button slot="footer" type="primary" fill>Add measurement</base-button>
        </div>
      </card>
    </div>
  </div>
</template>

<script>
import { BaseTable } from "@/components";

const tableColumns = ["Day", "Group"];
const tableData = [
  {
    day: "Monday",
    group: "Chest/Triceps"
  },
  {
    day: "Tuesday",
    group: "Back/Biceps"
  },
  {
    day: "Wednesday",
    group: "Legs"
  },
  {
    day: "Thursday",
    group: "Shoulders/Abs"
  },
  {
    day: "Friday",
    group: "Cardio/Abs"
  },
  {
    day: "Saturday",
    group: "Rest"
  },
  {
    day: "Sunday",
    group: "Chest/Triceps"
  }
];

export default {
  components: {
    BaseTable
  },
  data() {
    return {
      // weights: {
      //   columns: [...tableColumns],
      //   data: [...tableData]
      // }

      tableData
    };
  }
};
</script>
<style>
</style>