<template>
  <div class="row">
    <div class="col-md-12">
      <edit-profile-form :model="model"></edit-profile-form>
    </div>
  </div>
</template>
<script>
import Vue from "vue";
import EditProfileForm from "./Profile/EditProfileForm";
import { baseUrl } from "../shared/api";

const axios = require("axios");

var userModel = axios
  .get(`${baseUrl}api/self`, { withCredentials: true })
  .then(function(response) {
    // handle success
    console.log(response.data);
  })
  .catch(function(error) {
    // handle error
    console.log(error);
  })
  .then(function() {
    // always executed
  });

export default Vue.extend({
  name: "profile",
  components: {
    EditProfileForm
  },
  data() {
    return {
      model: {
        email: 'example@example.com',
        phoneNumber: '123456789'
      }
    }
  }
});
</script>
<style>
</style>
