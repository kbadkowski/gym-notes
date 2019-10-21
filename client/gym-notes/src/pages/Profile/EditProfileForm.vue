<template>
  <card>
    <h5 slot="header" class="title">User Details</h5>
    <div class="row">
      <div class="col-md-12 pr-md-3">
        <p>Email</p>
        <p class="text-primary">{{ model.email }}</p>
      </div>
    </div>
    <hr>
    <div class="row">
      <div class="col-md-12 pr-md-3">
        <p>Phone number</p>
        <p class="text-primary">{{ model.phoneNumber }}</p>
      </div>
    </div>
    <base-button 
    slot="footer"
    type="primary"
    fill 
    @click="goToManageAccount()">Edit</base-button>
  </card>
</template>
<script>
import { manageAccountUrl } from "../../shared/api";

export default {
  props: {
    model: {
      type: Object,
      default: () => {
        return {};
      }
    }
  },
  methods: {
    goToManageAccount() {
      window.location.href = manageAccountUrl;
    }
  }
};
</script>
<style>
</style>
