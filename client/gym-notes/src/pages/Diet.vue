<template>
  <div class="row">
    <h3>Here you can see list of your meals</h3>
    <div class="col-12 overflow-auto">
      <card type="tasks">
        <template slot="header">
          <h6 class="title d-inline">{{$t('diets', {count: tableData.length})}}</h6>
        </template>
        <div class="table-full-width bg-2 overflow-auto">
          <base-table :data="tableData" thead-classes="text-primary">
            <template slot-scope="{row}">
              <td>
                <p class="text-primary">{{row.date}}</p>
                <p class="title">{{row.kcal}}</p>
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
          <base-button slot="footer" type="primary" fill>Add meal</base-button>
        </div>
      </card>
    </div>
  </div>
</template>

<script>
import { BaseTable } from "@/components";

const tableColumns = ["Date", "Food", "Kcal"];
const tableData = [
  {
    date: "02-01-2020",
    kcal: "2340kcal"
  },
  {
    date: "13-01-2020",
    kcal: "2550kcal"
  },
  {
    date: "03-01-2020",
    kcal: "2600kcal"
  },
  {
    date: "04-01-2020",
    kcal: "2690kcal"
  },
  {
    date: "05-01-2020",
    kcal: "2800kcal"
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