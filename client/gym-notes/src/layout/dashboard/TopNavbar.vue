<template>
  <nav
    class="navbar navbar-expand-lg navbar-absolute"
    :class="{'bg-white': showMenu, 'navbar-transparent': !showMenu}"
  >
    <div class="container-fluid">
      <div class="navbar-wrapper">
        <div class="navbar-toggle d-inline" :class="{toggled: $sidebar.showSidebar}">
          <button type="button" class="navbar-toggler" @click="toggleSidebar">
            <span class="navbar-toggler-bar bar1"></span>
            <span class="navbar-toggler-bar bar2"></span>
            <span class="navbar-toggler-bar bar3"></span>
          </button>
        </div>
        <a class="navbar-brand" href="#pablo">{{routeName}}</a>
      </div>
      <button
        class="navbar-toggler"
        type="button"
        @click="toggleMenu"
        data-toggle="collapse"
        data-target="#navigation"
        aria-controls="navigation-index"
        aria-label="Toggle navigation"
      >
        <span class="navbar-toggler-bar navbar-kebab"></span>
        <span class="navbar-toggler-bar navbar-kebab"></span>
        <span class="navbar-toggler-bar navbar-kebab"></span>
      </button>

      <collapse-transition>
        <div class="collapse navbar-collapse show" v-show="showMenu">
          <ul class="navbar-nav ml-auto">
            <base-dropdown
              tag="li"
              :menu-on-right="true"
              title-tag="a"
              class="nav-item"
              menu-classes="dropdown-navbar"
            >
              <a
                slot="title"
                href="#"
                class="dropdown-toggle nav-link"
                data-toggle="dropdown"
                aria-expanded="true"
              >
                <div class="photo">
                  <img src="img/default-avatar.png" />
                </div>
                <b class="caret d-none d-lg-block d-xl-block"></b>
                <!-- <p class="d-lg-none">EMAIL GOES HERE</p> -->
              </a>
              <!-- <li class="nav-link">
                <p class="nav-item dropdown-item">EMAIL GOES HERE</p>
              </li> -->
              <li class="nav-link">
                <button @click="goToManageAccount()" class="nav-item dropdown-item">Profile</button>
              </li>
              <div class="dropdown-divider"></div>
              <li class="nav-link">
                <button @click="logout()" class="nav-item dropdown-item">Log out</button>
              </li>
            </base-dropdown>
          </ul>
        </div>
      </collapse-transition>
    </div>
  </nav>
</template>
<script lang="ts">
import { CollapseTransition } from "vue2-transitions";
import axios from "axios";
import { baseUrl, manageAccountUrl, logoutUrl } from "../../shared/api";

export default {
  components: {
    CollapseTransition
  },
  computed: {
    routeName() {
      const { name } = this.$route;
      return this.capitalizeFirstLetter(name);
    }
    // getUserInfo() {
    //   axios.get(baseUrl + 'api/self', {
    // })
    // .then(function (response) {
    // console.log(response);
    // })
    // return Response;
    // }
  },
  data() {
    return {
      showMenu: false
    };
  },
  methods: {
    capitalizeFirstLetter(string) {
      return string.charAt(0).toUpperCase() + string.slice(1);
    },
    toggleNotificationDropDown() {
      this.activeNotifications = !this.activeNotifications;
    },
    closeDropDown() {
      this.activeNotifications = false;
    },
    toggleSidebar() {
      this.$sidebar.displaySidebar(!this.$sidebar.showSidebar);
    },
    hideSidebar() {
      this.$sidebar.displaySidebar(false);
    },
    toggleMenu() {
      this.showMenu = !this.showMenu;
    },
    logout() {
      // var logoutResult = axios(_logoutUrl, {
      //   method: "post",
      //   withCredentials: true
      // });
      window.location.href = manageAccountUrl;
    },
    goToManageAccount() {
      window.location.href = manageAccountUrl;
    }
  }
};
</script>
<style>
</style>
