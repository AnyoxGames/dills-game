13
4221952851969
404980503802924 1761863316527033200
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -1.1055822372436523,
    "Y": -10.9241800308227539
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404978072721389:1761863315960588800",
  "next_sibling": "404983293587500:1761863317177055600",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404980504040112:1761863316527087300",
  "component_type": "Internal_Component",
  "internal_component_type": "Interactable",
  "data": {
    "text": "Harvest Pine Tree",
    "radius": 1,
    "required_hold_time": 0.3000000119209290
  }
},
{
  "cid": 4,
  "aoid": "404980504158835:1761863316527115000",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404980504040112:1761863316527087300",
    "DefaultRenderer": "404980504208371:1761863316527126500",
    "DepletedRenderer": "404980504191558:1761863316527122600"
  }
},
{
  "cid": 5,
  "aoid": "404980504171477:1761863316527117900",
  "component_type": "Internal_Component",
  "internal_component_type": "Polygon_Collider",
  "data": {
    "make_navmesh_loop": true,
    "flip_navmesh_loop": true,
    "points": [
      {
        "X": -0.1877212524414062,
        "Y": -0.2063050270080566
      },
      {
        "X": 0.0189009904861450,
        "Y": -0.2597980499267578
      },
      {
        "X": 0.2158927917480469,
        "Y": -0.1123766899108887
      },
      {
        "X": 0.0703394412994385,
        "Y": 0.1123763322830200
      },
      {
        "X": -0.1783308982849121,
        "Y": 0.0560193061828613
      }
    ]
  }
}
