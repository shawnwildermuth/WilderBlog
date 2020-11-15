<template>
  <span v-if="model.$invalid" class="text-danger">
    <ul class="list-unstyled">
      <li v-for="e in model.$errors" :key="e.$message">
        <small>
          <em>
            <slot>{{ e.$message }}</slot>
          </em>
        </small>
      </li>
    </ul>
  </span>
</template>
<script>
export default {
  props: {
    model: {
      required: true,
    },
  },
};
</script>