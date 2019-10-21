<template>
  <footer class="footer">
    <div class="container-fluid">
      <div class="copyright">© {{ footerData.year }} - {{ footerData.title }} - All rights reserved</div>
    </div>
  </footer>
</template>
<script>
export default {
  data() {
    return {
      footerData: {
        year: new Date().getFullYear(),
        title: "Gym Notes"
      }
    };
  }
};
</script>
<style>
</style>
