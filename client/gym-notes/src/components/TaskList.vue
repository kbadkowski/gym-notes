<template>
  <base-table :data="tableData" thead-classes="text-primary">
    <template slot-scope="{row}">
      <td>
        <base-checkbox v-model="row.done"></base-checkbox>
      </td>
      <td>
        <p class="text-primary">{{row.date}}</p>
        <p class="title">{{row.title}}</p>
        <p class="text-info">{{row.content}}</p>
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
</template>
<script>
import { BaseTable } from "@/components";

var taskList = [
    {
      "title": "Update gym notes",
      "date": "12-01-2020",
      "done": false
    },
    {
      "title": "Buy proteins",
      "content": "Buy proteins from my fav shop",
      "date": "17-01-2020",
      "done": true
    },
    {
      "title": "Increase max weight volume in next week",
      "date": "06-02-2020",
      "done": false
    }
  ];

export default {
  components: {
    BaseTable
  },
  computed: {
    tableData() {
      return taskList;
    }
  }
};
</script>
<style>
</style>
