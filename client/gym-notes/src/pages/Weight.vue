<template>
  <div class="row">
    <h3>Here you can see list of your weight</h3>
    <div class="col-12 overflow-auto">
      <card type="tasks">
        <template slot="header">
          <h6 class="title d-inline">{{$t('weights', {count: tableData.length})}}</h6>
        </template>
        <div class="table-full-width bg-2 overflow-auto">
          <base-table :data="tableData" thead-classes="text-primary">
            <template slot-scope="{row}">
              <td>
                <p class="text-primary">{{row.date}}</p>
                <p class="title">{{row.weight}}</p>
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

const tableColumns = ["Date", "Weight"];
const tableData = [
  {
    date: "02-01-2019",
    weight: "84.2kg"
  },
  {
    date: "03-02-2019",
    weight: "85.2kg"
  },
  {
    date: "10-05-2019",
    weight: "88.1kg"
  },
  {
    date: "11-07-2019",
    weight: "89.2kg"
  },
  {
    date: "23-10-2019",
    weight: "90.2kg"
  },
  {
    date: "30-12-2019",
    weight: "89.5kg"
  },
  {
    date: "02-12-2020",
    weight: "93.1kg"
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