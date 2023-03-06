<template>
  <div class="boxs" style="width: 200px;">
    <br/>
        <p class="menu-label">
          Actions
        </p>
        <ul class="menu-list">
          <li><a @click="toggleModal" class="menu-list-text-color">Add To-Do task</a></li>
          <li><a @click="updateData" class="menu-list-text-color">Refresh table</a></li>
          <li><a class="menu-list-text-color">Not completed tasks</a></li>
          <li><a class="menu-list-text-color">Completed tasks</a></li>
        </ul>
        <br/>
    </div>
</template>
<script>
export default {
  data () {
    return {
    }
  },
  methods: {
    updateData () {
      this.$emit('updateData')
    },
    toggleModal () {
      this.$emit('toggleModal')
    }
  }
}
</script>
<style>
.menu-list-text-color{
  color:#BEB7A4 !important
}
.menu-label{
  text-align: center;
  color: #c19921;
  font-weight: bold;
}
.side, .boxs{
    margin-left: 5px;
    margin-right: 85%;
    border-radius: 25px;
    background-color: black;
}
</style>
