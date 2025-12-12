13
4179003179009
404976569700760 1761863315610383100
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": 0.4551029205322266,
    "Y": -11.2662477493286133
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404975426058312:1761863315343913400",
  "next_sibling": "404978072721389:1761863315960588800",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404976569946677:1761863315610439400",
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
  "aoid": "404976570080579:1761863315610470600",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404976569946677:1761863315610439400",
    "DefaultRenderer": "404976570128395:1761863315610481800",
    "DepletedRenderer": "404976570112915:1761863315610478200"
  }
},
{
  "cid": 5,
  "aoid": "404976570092533:1761863315610473400",
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
