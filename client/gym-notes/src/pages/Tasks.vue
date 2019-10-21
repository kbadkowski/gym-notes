<template>
  <div>
    <h3>Here you can see list of tasks</h3>
    <div class="table-full-width overflow-auto">
      <task-list></task-list>
    </div>
    <div class="pt-3 mt-3">
    <base-button slot="footer" type="primary" fill class="float-left">Add task</base-button>
    </div>
  </div>
</template>
<script>
import TaskList from "../components/TaskList";

export default {
  components: {
    TaskList
  }
};
</script>
<style>
</style>
